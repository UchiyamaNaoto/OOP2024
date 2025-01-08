from panda3d.core import *

class Geometry:
  lINE_LENGTH = 10000
  LINE_DISTANCE = 50
  LINE_NUM = 100
  
  def __init__(self):
    self.geometry_node = self.render.attachNewNode(PandaNode('geometry_node'))
    self.draw_axis()
    self.draw_solar_system_plane()
    
  def draw_axis(self):
    self.draw_line_between_two_points(Point3(0, 0, 0), Point3(self.lINE_LENGTH, 0, 0), (1, 0, 0), self.geometry_node)
    self.draw_line_between_two_points(Point3(0, 0, 0), Point3(0, self.lINE_LENGTH, 0), (0, 1, 0), self.geometry_node)
    self.draw_line_between_two_points(Point3(0, 0, 0), Point3(0, 0,self.lINE_LENGTH), (0, 0, 1), self.geometry_node)
  
  def draw_solar_system_plane(self):
      for j in range(3):
        plane_node = self.geometry_node.attachNewNode(PandaNode('plane_node'))
        plane_node.setH(120 * j)
        
        for i in range(-self.LINE_NUM, self.LINE_NUM + 1):
          x = self.LINE_NUM * self.LINE_DISTANCE / 2
          y = i * self.LINE_DISTANCE
          position1 = Point3(-x, y, 0)
          position2 = Point3(x, y, 0)
          self.draw_line_between_two_points(
            position1, position2, (0.5, 0.5, 0), plane_node, thickness=2)

  def draw_orbit(self, planet, line_color='', is_second_orbit=False):
    if not line_color:
      line_color = planet.line_color
      
    if is_second_orbit:
      position1 = planet.pre_position_second
      position2 = planet.position_second
    else:
      position1 = planet.pre_position
      position2 = planet.position
      
    if position1 is not None and position2 is not None and position1 != position2:
      self.draw_line_between_two_points(
        position1, position2, line_color, self.geometry_node)

  @staticmethod
  def draw_line_between_two_points(position1, position2, line_color, parent, thickness=4):
    line_segs = LineSegs()
    line_segs.setColor(*line_color, 1)
    line_segs.moveTo(position1)
    line_segs.drawTo(position2)
    line_segs.setThickness(thickness)
    line_node = line_segs.create()
    NodePath(line_node).reparentTo(parent)