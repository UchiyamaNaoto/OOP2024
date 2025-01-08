PLANET_DICT_LIST = [
  # 名前、半径、公転半径、公転周期、惑星の色、軌跡の色、初期角度（1986年1月1日の位置）、惑星を表す識別子
  dict(name='Sun', radius=0.1, orbit_radius=0, orbit_period=1,
       color=(1, 1, 1), line_color=(0, 1, 1), heading=0, horizons_id=10),
  dict(name='Mercury', radius=0.383, orbit_radius=0.387, orbit_period=0.241,
       color=(0.5, 0.5, 0.5), line_color=(0, 1, 1), heading=221.783, horizons_id=199),
  dict(name='Venus', radius=0.949, orbit_radius=0.723, orbit_period=0.615,
       color=(1, 0.5, 0), line_color=(0, 1, 1), heading=269.983, horizons_id=299),
  dict(name='Earth', radius=1.000, orbit_radius=1.000, orbit_period=1.000,
       color=(0, 0, 1), line_color=(0, 1, 1), heading=100.469, horizons_id=399),
  dict(name='Mars', radius=0.532, orbit_radius=1.524, orbit_period=1.881,
       color=(1, 0, 0), line_color=(0, 1, 1), heading=189.549, horizons_id=499),
  dict(name='Jupiter', radius=11.209, orbit_radius=5.203, orbit_period=11.862,
       color=(0, 1, 0), line_color=(0, 1, 1), heading=325.363, horizons_id=599),
  dict(name='Saturn', radius=9.449, orbit_radius=9.537, orbit_period=29.457,
       color=(0.5, 0, 0.5), line_color=(0, 1, 1), heading=242.112, horizons_id=699),
  dict(name='Uranus', radius=4.007, orbit_radius=19.191, orbit_period=84.017,
       color=(0, 1, 1), line_color=(0, 1, 1), heading=258.660, horizons_id=799),
  dict(name='Neptune', radius=3.883, orbit_radius=30.069, orbit_period=164.791,
       color=(0, 0, 0.5), line_color=(0, 1, 1), heading=273.575, horizons_id=899),
]
YEAR_IN_DAYS = 365.256363
BASE_ORBIT_RADIUS = 20
BASE_ROTATE_SPEED = 360 / YEAR_IN_DAYS
MONTH_NAME_LIST = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
MONTH_PASSED_DAYS_LIST = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334]