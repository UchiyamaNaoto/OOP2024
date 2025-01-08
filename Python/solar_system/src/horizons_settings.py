HALLEY_DICT_LIST = [
  dict(name='Halley', radius=0.1, orbit_radius=0, orbit_period=1, color=(1, 1, 1), line_color=(1, 0, 0), heading=None, horizons_id=90000030),
]
HALLEY_SETTINGS = {
  'start_time': '1986-01-01', # ハレー彗星（前回の最接近日）
  'stop_time': '2062-01-01', # ハレー彗星（76年間データを取得）
  'step_size': '7d' # ハレー彗星 データを取得する間隔（日=d）
}
HAYABUSA2_DICT_LIST = [
  dict(name='Hayabusa2', radius=0.1, orbit_radius=0, orbit_period=1,
       color=(1, 1, 1), line_color=(1, 0.5, 0), heading=None, horizons_id=-37),
  dict(name='Ryugu', radius=0.1, orbit_radius=0, orbit_period=1,
       color=(1, 1, 1), line_color=(1, 1, 0), heading=None, horizons_id=162173),
]
HAYABUSA2_SETTINGS = {
  'start_time': '2014-12-04', # はやぶさ2打ち上げ
  'stop_time': '2020-12-06', # はやぶさ2帰還
  'step_size': '1d' # はやぶさ2 データを取得する間隔（日=d)
}