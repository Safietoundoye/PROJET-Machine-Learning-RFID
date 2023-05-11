from flask import Flask, jsonify , request 
import requests
import json
from MLRFID_Projet_S8 import analytical
import pandas as pd


app = Flask(__name__)

@app.route('/analytical', methods=['GET'])
def analytical_route():
    # Charger les DataFrames a partir des fichiers CSV
    tags = pd.read_csv("C:\\Users\\Public\\Downloads\\csv\\csv\\df_timing_slices.csv")
    subslices = pd.read_csv("C:\\Users\\Public\\Downloads\\csv\\csv\\timing_slices.csv")
    # Call the predict() function to make a prediction
    analytic = analytical(tags , subslices)
    # Return the prediction as JSON
    return jsonify({'analytic': analytic})


@app.route('/analyticalWithParams', methods=['GET'])
def analyticalWithParams_route():
    # Charger les DataFrames a partir des fichiers CSV
    tags = pd.read_csv("C:\\Users\\Public\\Downloads\\csv\\csv\\df_timing_slices.csv")
    subslices = pd.read_csv("C:\\Users\\Public\\Downloads\\csv\\csv\\timing_slices.csv")
    # Call the predict() function to make a prediction
    analytic = analytical(tags , subslices)
    # Return the prediction as JSON
    return jsonify({'analytic': analytic})
app.run(host='0.0.0.0', port=5000)


