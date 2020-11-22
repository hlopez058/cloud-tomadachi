import os

path = os.path.dirname(os.path.abspath(__file__))

with open(os.path.join(path,'cf_test.yaml'))as f:
    raw = f.read()
    getServices(raw)

def getServices(context):   
    
