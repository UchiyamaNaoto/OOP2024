from math import acos, atan2, sin, cos, degrees, radians
from panda3d.core import Point3

def convert_to_polar(vector):
  x, y, z = vector
  r = vector.length()
  theta = degrees(acos(z / r))
  phi = degrees(atan2(y, x))
  return r, theta, phi

def convert_to_cartesian(r, theta, phi):
  rad_theta, rad_phi = radians(theta), radians(phi)
  x = r * sin(rad_theta) * cos(rad_phi)
  y = r * sin(rad_theta) * sin(rad_phi)
  z = r * cos(rad_theta)
  return x, y, z

def get_heading(end_vec, start_vec=Point3(0, 0, 0)):
  relative_vector = end_vec - start_vec
  heading = degrees(atan2(relative_vector.y, relative_vector.x))
  return heading if heading >= 0 else heading + 360