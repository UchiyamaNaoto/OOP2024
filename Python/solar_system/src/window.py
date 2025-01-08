from panda3d.core import WindowProperties
from . import Draw2DText

class Window:
  def __init__(self):
    self.props = WindowProperties()
    self.props.setTitle('太陽系')
    self.props.setSize(1200, 800)
    self.win.requestProperties(self.props)
    self.setBackgroundColor(0, 0, 0)
    
    self.speed = 1
    self.accept('u', self.speed_control, [1])
    self.accept('d', self.speed_control, [-1])
    self.accept('escape', exit)
    
    self.top_left_text = Draw2DText(self.a2dTopLeft)
    self.bottom_left_text = Draw2DText(self.a2dBottomLeft, 'Speed: 1', pos=(0.05, 0.1))

  def speed_control(self, diff_speed):
    if (-10 < self.speed and diff_speed == -1) or (self.speed < 10 and diff_speed == 1):
      self.speed += diff_speed
      print('speed:', self.speed)
      
    if self.speed == 0:
      self.bottom_left_text.setText('Stop')
    else:
      self.bottom_left_text.setText(f'Speed: {self.speed}')