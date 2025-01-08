from panda3d.core import *
from . import convert_to_polar, get_heading, Draw3DText, BASE_ORBIT_RADIUS

class Planet:
  def __init__(self, base, planet_dict):
    self.base = base
    self.planet_dict = planet_dict
    self.name = planet_dict['name']
    self.radius = planet_dict['radius']
    self.orbit_radius = planet_dict['orbit_radius'] * BASE_ORBIT_RADIUS
    self.orbit_period = planet_dict['orbit_period']
    self.initial_heading = planet_dict['heading']
    self.line_color = planet_dict['line_color']
    self.pre_position = None
    self.pre_position_second = None
    self.position = None
    self.position_second = None
    self.advanced_angle = 0

    self.planet_model_node = self.base.solar_system_node.attachNewNode(PandaNode(f'{self.name}_model'))
    self.planet_model = self.base.loader.loadModel("models/smiley")
    self.planet_model.setColor(*self.planet_dict['color'], 1)
    self.planet_model.setTextureOff(1)
    self.planet_model.setScale(self.radius, self.radius, self.radius)
    self.planet_model.reparentTo(self.planet_model_node)

    self.planet_line_node = self.base.solar_system_node.attachNewNode(PandaNode(f'{self.name}_line'))
    self.base.draw_line_between_two_points(
      Point3(self.orbit_radius, 0, 0), Point3(0, 0, 0), (1, 0.5, 0), self.planet_line_node, thickness=2)

    self.planet_camera_node = self.planet_model_node.attachNewNode(PandaNode(f'{self.name}_camera'))
    self.planet_camera_node_heading = 0
    self.camera_axis = self.base.loader.loadModel('models/misc/xyzAxis')
    self.camera_axis.setScale(0.15)
    self.camera_axis.reparentTo(self.planet_camera_node)
    self.camera_axis.hide()

    self.label_text = Draw3DText(
      self.planet_model_node, self.name, self.base.LABEL_TEXT_SCALE, pos=Vec2(0, self.radius * 1.2))

  def update_label_node(self):
    # ラベルをカメラの方向に向けるための角度を計算
    _, theta, phi = convert_to_polar(self.base.camera.getPos())
    # 基準となる惑星のカメラノードの角度を取得
    referenced_planet = self.base.planet_instance_dict[self.base.referenced_planet_name]
    present_camera_node_heading = referenced_planet.planet_camera_node_heading
    # ラベルをカメラの方向に向ける
    label_node = self.planet_model_node.find('label_node')
    label_node.setHpr(phi + present_camera_node_heading + 90, theta - 90, 0)

  def update_camera_node(self):
    end_position = self.position
    start_position = self.pre_position
    
    if end_position is not None and start_position is not None:
      direction_vec = get_heading(end_position, start_position)
      if direction_vec:
        self.planet_camera_node_heading = direction_vec - 90
        self.planet_camera_node.setH(self.planet_camera_node_heading)

  def update_advanced_heading(self):
    position1 = self.pre_position
    position2 = self.position
    
    if position1 is not None and position2 is not None and position1 != position2:
      heading = get_heading(self.position)
      pre_heading = get_heading(self.pre_position)
      diff_angle = heading - pre_heading
      
      if self.base.speed > 0:
        if diff_angle >= 0:
          self.advanced_angle += diff_angle
        else:
          self.advanced_angle += diff_angle + 360
      else:
        if diff_angle <= 0:
          self.advanced_angle += diff_angle
        else:
          self.advanced_angle += diff_angle - 360

  def update(self):
    self.update_camera_node()
    self.update_label_node()
    self.update_advanced_heading()