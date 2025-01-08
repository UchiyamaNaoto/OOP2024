from direct.showbase.ShowBase import ShowBase
from src import *

class App(ShowBase, Window, Camera, Geometry, MakePlanets):
  def __init__(self):
    ShowBase.__init__(self)
    Window.__init__(self)
    Camera.__init__(self)
    Geometry.__init__(self)
    MakePlanets.__init__(self, PLANET_DICT_LIST)

    self.count = 0

    self.taskMgr.doMethodLater(0.1, self.update_planets, 'update_planets')

  def update_planets(self, task):
    for name, planet in self.planet_instance_dict.items():
      if name != 'Sun':
        diff_heading = BASE_ROTATE_SPEED * self.count / planet.orbit_period
        heading = planet.initial_heading + diff_heading
        position = Point3(*convert_to_cartesian(planet.orbit_radius, 90, heading))
        planet.planet_model_node.setPos(position)
        planet.pre_position = planet.position
        planet.position = position
        planet.planet_line_node.setH(heading)
        
        if diff_heading <= 400:
          self.draw_orbit(planet)
          
        if name == 'Mercury':
          self.update_top_left_text()

      planet.update()

    self.count += self.speed
    return task.again

  def update_top_left_text(self):
    passed_years = self.count // 365
    count = self.count - passed_years * 365
    month, day = '', ''

    for month_name, passed_days in zip(reversed(MONTH_NAME_LIST), reversed(MONTH_PASSED_DAYS_LIST)):
      if count >= passed_days:
        month = month_name
        day = count - passed_days + 1
        break

    top_left_text = f'{1986 + passed_years}-{month}-{day}'
    print(top_left_text)
    self.top_left_text.setText(top_left_text)

app = App()
app.run()