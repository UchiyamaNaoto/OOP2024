import time
from astroquery.jplhorizons import Horizons

def get_vectors_dict(planet_dict_list, api_settings):
  start = api_settings['start_time']
  stop = api_settings['stop_time']
  step = api_settings['step_size']
  vectors_dict = {}

  for planet_dict in planet_dict_list:
    name = planet_dict['name']
    horizons_id = planet_dict['horizons_id']

    if name != 'Sun':
      obj = Horizons(id=horizons_id, location='@sun',
                     epochs={'start': start, 'stop': stop,'step': step})
      vectors = obj.vectors()
      vectors_dict[name] = vectors
      print('Received complete:', name)
      
      time.sleep(10)

  return vectors_dict