from direct.gui.DirectGui import OnscreenText
from panda3d.core import TextNode, PandaNode

class Draw2DText(OnscreenText):
  def __init__(self, parent, text='', scale=0.07, pos=(0.05, -0.1)):
    super().__init__(parent=parent, text=text, scale=scale, pos=pos, fg=(1, 1, 1, 1), align=TextNode.ALeft, mayChange=True)

class Draw3DText(OnscreenText):
  def __init__(self, parent, text, scale, pos):
    label_node = parent.attachNewNode(PandaNode('label_node'))
    super().__init__(parent=label_node, text=text, scale=scale, pos=pos, fg=(1, 1, 1, 1))