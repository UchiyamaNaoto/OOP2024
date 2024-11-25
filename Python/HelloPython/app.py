
from flask import Flask

app = Flask(__name__)

def hello():
    return "Hello Python!"

if __name__ == '__main__':
    app.run('localhost,4449')