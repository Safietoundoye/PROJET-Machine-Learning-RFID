from flask import Flask, jsonify , request 
import requests
import json
from MLRFID_Projet_S8_RandomForest import result
from MLRFID_Projet_S8_RandomForest import RandomForestML
from MLRFID_Projet_S8_RandomForest import logistic_regression
from MLRFID_Projet_S8_RandomForest import train_svc_model
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


@app.route('/LRClassifier', methods=['POST'])
def LRClassifier_route():
    # Charger les DataFrames a partir des fichiers CSV
    params1 = request.get_json()
    # Call the predict() function to make a prediction
    MLLR = logistic_regression(params1['Hyperparameter1'], float(params1['Hyperparameter2']), params1['Hyperparameter3'])
    # Return the prediction as JSON
    return jsonify({'MLLR': MLLR})


@app.route('/SVCClassifier', methods=['POST'])
def SVCClassifier_route():
    # Charger les DataFrames a partir des fichiers CSV
    params3 = request.get_json()
    # Call the predict() function to make a prediction
    MLSVC = train_svc_model(params3['Hyperparameter1'], float(params3['Hyperparameter2']), float(params3['Hyperparameter3']), int(params3['Hyperparameter4']), int(params3['Hyperparameter5']), float(params3['Hyperparameter6']))
    # Return the prediction as JSON
    return jsonify({'MLSVC': MLSVC})

app.run(host='0.0.0.0', port=5000)


