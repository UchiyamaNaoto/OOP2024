from panda3d.core import Point3
from . import convert_to_cartesian

class Camera:
  BASE_CAMERA_RADIUS = 1000
  
  def __init__(self):
    self.disableMouse()
    self.camera_radius = self.BASE_CAMERA_RADIUS
    self.camera_theta = 60
    self.camera_phi = -75
    self.referenced_planet_name = 'Sun'
    self.camera_set_pos()
    
    self.accept('arrow_right-repeat', self.change_camera_angle, [0, 1])
    self.accept('arrow_left-repeat', self.change_camera_angle, [0, -1])
    self.accept('arrow_up-repeat', self.change_camera_angle, [-1, 0])
    self.accept('arrow_down-repeat', self.change_camera_angle, [1, 0])
    self.accept('wheel_up', self.change_camera_radius, [1.25])
    self.accept('wheel_down', self.change_camera_radius, [0.8])
    self.accept('c', self.change_referenced_planet)

  def change_camera_angle(self, theta, phi):
    self.camera_theta += theta
    self.camera_phi += phi
    if self.camera_theta <= 0:
      self.camera_theta = 0.0000001
    if 180 <= self.camera_theta:
      self.camera_theta = 180 - 0.0000001
    self.camera_set_pos()
    
  def change_camera_radius(self, rate):
    self.camera_radius *= rate
    self.change_label_font_size()
    self.camera_set_pos()
    
  def camera_set_pos(self):
    radius = self.camera_radius
    theta = self.camera_theta
    phi = self.camera_phi
    position = Point3(*convert_to_cartesian(radius, theta, phi))
    self.camera.setPos(position)
    self.camera.lookAt(0, 0, 0)

  def change_label_font_size(self):
    for planet in self.planet_instance_dict.values():
      rate = self.camera_radius / self.BASE_CAMERA_RADIUS
      planet.label_text.setScale(self.LABEL_TEXT_SCALE * rate)

  def change_referenced_planet(self):
    present_planet_name = self.referenced_planet_name
    present_planet = self.planet_instance_dict[present_planet_name]
    present_planet.camera_axis.hide()
    
    planet_names = list(self.planet_instance_dict.keys())
    next_planet_id = planet_names.index(self.referenced_planet_name) + 1
    self.referenced_planet_name = planet_names[next_planet_id % len(planet_names)]
    next_planet = self.planet_instance_dict[self.referenced_planet_name]
    self.camera.reparentTo(next_planet.planet_camera_node)
    next_planet.camera_axis.show()