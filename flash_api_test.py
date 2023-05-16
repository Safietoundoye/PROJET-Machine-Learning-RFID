from flask import Flask, jsonify , request 
import requests
import json
from MLRFID_Projet_S8_RandomForest import result
from MLRFID_Projet_S8_RandomForest import RandomForestML
import pandas as pd


app = Flask(__name__)

@app.route('/analytical', methods=['POST'])
def analytical_route():

    # Call the predict() function to make a prediction
    analytic = result()
    # Return the prediction as JSON
    return jsonify({'analytic': analytic})


@app.route('/RFClassifier', methods=['POST'])
def analyticalWithParams_route():
    # Charger les DataFrames a partir des fichiers CSV
    params = request.get_json()
    # Call the predict() function to make a prediction
    MLRF = RandomForestML(int(params['Hyperparameter1']), int(params['Hyperparameter2']))
    # Return the prediction as JSON
    return jsonify({'MLRF': MLRF})

app.run(host='0.0.0.0', port=5000)


