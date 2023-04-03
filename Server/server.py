from flask import Flask, request
import os, json

server = Flask(__name__)

@server.route("/push", methods=["post"])
def push():
    data = request.json
    # SaveData(data)
    return data

@server.route("/pull", methods=["get"])
def pull():
    return "{\"user\":\"user\",\"pass\":\"1234\"}"

def SaveData(data):
    file = open(os.getcwd()+"/file.json", "w")
    json.dump(data, file)

if __name__ == "__main__":
    server.run(debug=True, host="0.0.0.0", port=1234)