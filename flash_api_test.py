from flask import Flask, jsonify , request 
import requests
import json
from MLRFID_Script_Complet import result
from MLRFID_Script_Complet import RandomForestML
from MLRFID_Script_Complet import logistic_regression
from MLRFID_Script_Complet import train_svc_model
from MLRFID_Script_Complet import knn_classifier
from MLRFID_Script_Complet import compare_resultats
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
    params1 = request.get_json()
    # Call the predict() function to make a prediction
    MLRF = RandomForestML(int(params1['Hyperparameter1']), int(params1['Hyperparameter2']))
    # Return the prediction as JSON
    return jsonify({'MLRF': MLRF})


@app.route('/LRClassifier', methods=['POST'])
def LRClassifier_route():
    # Charger les DataFrames a partir des fichiers CSV
    params2 = request.get_json()
    # Call the predict() function to make a prediction
    MLLR = logistic_regression(params2['Hyperparameter1'], float(params2['Hyperparameter2']), params2['Hyperparameter3'])
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

@app.route('/KNNClassifier', methods=['POST'])
def KNNClassifier_route():
    # Charger les DataFrames a partir des fichiers CSV
    params4 = request.get_json()
    # Call the predict() function to make a prediction
    MLKNN = knn_classifier(int(params4['Hyperparameter1']), params4['Hyperparameter2'], params4['Hyperparameter3'], params4['Hyperparameter4'])
    # Return the prediction as JSON
    return jsonify({'MLKNN': MLKNN})

#@app.route('/KNNClassifier', methods=['POST'])
#def KNNClassifier_route():
#    # Charger les DataFrames a partir des fichiers CSV
#    params1 = request.get_json()
#    params2 = request.get_json()
#    params3 = request.get_json()
#    params4 = request.get_json()
#    # Call the predict() function to make a prediction
#    Nom_methode = []
#    Valeur_resultats = []

   # if params1 != "null" :
   #     Nom_methode.append("RandomForestML")
   #     MLRF = RandomForestML(int(params1['Hyperparameter1']), int(params1['Hyperparameter2']))
   #     Valeur_resultats.append(MLRF)

   # if params2 != "null" :
   #     Nom_methode.append("logistic_regression")
   #     MLLR = logistic_regression(params2['Hyperparameter1'], float(params2['Hyperparameter2']), params2['Hyperparameter3'])
   #     Valeur_resultats.append(MLLR)

   # if params3 != "null" :
   #     Nom_methode.append("train_svc_model")
   #     MLSVC = train_svc_model(params3['Hyperparameter1'], float(params3['Hyperparameter2']), float(params3['Hyperparameter3']), int(params3['Hyperparameter4']), int(params3['Hyperparameter5']), float(params3['Hyperparameter6']))
   #     Valeur_resultats.append(MLSVC)

   # if params4 != "null" :
   #     Nom_methode.append("knn_classifier")
   #     MLKNN = knn_classifier(int(params4['Hyperparameter1']), params4['Hyperparameter2'], params4['Hyperparameter3'], params4['Hyperparameter4'])
   #     Valeur_resultats.append(MLKNN)

    

   # Liste_methode = {
   # "Analytical": {
   #     "nb_arbre ": "123 Main Street",
   #     "max_profondeur": "New York"
   # },
   # "RandomForestML": {
   #     "nb_arbre ": "123 Main Street",
   #     "max_profondeur": "New York",
   # },
   # "Logistic_Regression": {
   #     "Penalty": "123 Main Street",
   #     "C": "New York",
   #     "Solver": "USA"
   # },
   # "contacts": {
   #     "email": "johndoe@example.com",
   #     "phone": "555-1234"
   # },
   # "contacts": {
   #     "email": "johndoe@example.com",
   #     "phone": "555-1234"
   # },
   # "contacts": {
   #     "email": "johndoe@example.com",
   #     "phone": "555-1234"
   # },
   #}

   # MLKNN = knn_classifier(Nom_methode, Valeur_resultats)
   # # Return the prediction as JSON
   # return jsonify({'MLKNN': MLKNN})


app.run(host='0.0.0.0', port=5000)


