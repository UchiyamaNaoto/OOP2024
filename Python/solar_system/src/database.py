import sqlite3
from . import get_vectors_dict

class Database:
  def __init__(self):
    self.db = sqlite3.connect('data/horizons_api.sqlite3')
    self.db_cursor = self.db.cursor()
    self.create_table()
    self.insert_data()
    self.row_length = self.count_rows()

  def check_empty_table(self):
    self.db_cursor.execute(
      f'SELECT count(*) from {self.table_name}')
    result = self.db_cursor.fetchone()[0]
    return result == 0

  def create_table(self):
    self.db_cursor.execute(
      f'CREATE TABLE IF NOT EXISTS {self.table_name}'
      '(name TEXT, date_str TEXT, x REAL, y REAL, z REAL)')

  def insert_data(self):
    if self.check_empty_table():
      vectors_dict = get_vectors_dict(self.planet_dict_list, self.api_settings)

      for name, vectors in vectors_dict.items():
        for vector in vectors:
          inserts = (
            name, vector['datetime_str'].split()[1],
            vector['x'], vector['y'], vector['z'])

          self.db_cursor.execute(
            f'INSERT INTO {self.table_name}(name, date_str, x, y, z) '
            f'VALUES (?, ?, ?, ?, ?)', inserts)
          
    self.db.commit()

  def count_rows(self):
    self.db_cursor.execute(
      f'SELECT count(*) from {self.table_name} WHERE name="Mercury"')
    result = self.db_cursor.fetchone()[0]
    return result

  def fetch_position(self, name):
    self.db_cursor.execute(
      f'SELECT date_str, x, y, z FROM {self.table_name} '
      f'WHERE name="{name}" LIMIT 1 OFFSET {self.count}'
    )
    result = self.db_cursor.fetchone()
    return result