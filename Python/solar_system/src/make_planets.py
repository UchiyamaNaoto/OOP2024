from panda3d.core import *
from . import Planet

class MakePlanets:
  LABEL_TEXT_SCALE = 15

  def __init__(self, planet_dict_list):
    self.planet_dict_list = planet_dict_list
    self.solar_system_node = self.render.attachNewNode(PandaNode('solar_system_node'))
    self.planet_instance_dict = {}

    for i, planet_dict in enumerate(self.planet_dict_list):
      name = planet_dict['name']

      self.planet_instance_dict[name] = Planet(self, planet_dict)