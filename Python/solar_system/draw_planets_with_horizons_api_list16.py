from direct.showbase.ShowBase import ShowBase
from src import *

table_name = 'HALLEY'
# table_name = 'HAYABUSA2'
global_obj = globals()
dict_list_to_add = global_obj[f'{table_name}_DICT_LIST']
api_settings = global_obj[f'{table_name}_SETTINGS'] 

class App(ShowBase, Window, Camera, Geometry, MakePlanets, Database):
  def __init__(self):
    ShowBase.__init__(self)
    Window.__init__(self)
    Camera.__init__(self)
    Geometry.__init__(self)
    MakePlanets.__init__(self, PLANET_DICT_LIST)

    self.table_name = table_name
    self.api_settings = api_settings
    Database.__init__(self)

    self.count = 0

    self.taskMgr.doMethodLater(0.1, self.update_planets, 'update_planets')

  def update_planets(self, task):
    for name, planet in self.planet_instance_dict.items():
      if name != 'Sun':
        result = self.fetch_position(name)

        if result:
          date_str, x, y, z = result 
          position = Point3(x, y, z) * BASE_ORBIT_RADIUS
          planet.planet_model_node.setPos(position)
          planet.pre_position = planet.position
          planet.position = position
          top_left_text = date_str

          if planet.advanced_angle <= 400 or name == 'Hayabusa2':
            self.draw_orbit(planet) 

          if name == 'Mercury':
            self.top_left_text.setText(top_left_text)
        else:
          print('Position not found in database')

        # 等速円運動との比較
        diff_heading = BASE_ROTATE_SPEED * self.count * 7 / planet.orbit_period
        heading = planet.initial_heading + diff_heading
        position_second = Point3(*convert_to_cartesian(planet.orbit_radius, 90, heading))
        planet.pre_position_second = planet.position_second
        planet.position_second = position_second
        planet.planet_line_node.setH(heading)

        if diff_heading <= 400:
          self.draw_orbit(planet, line_color=(1, 0.5, 0), is_second_orbit=True)
        # 等速円運動との比較（ここまで）

      planet.update()

    self.count += self.speed
    print('count:', self.count)

    if self.count < 0:
      self.count = 0
    elif self.count > self.row_length - 1:
      self.count = self.row_length - 1
    return task.again

app = App()
app.run()
