# Projet Machine Learning & RFID

---------

## Groupe 2 : Séssi Imorou Karimou Rouchdane, Co Mathieu, Ndoye Safiétou, Dia Ibrahima 

----------

### Description

---

Notre groupe a pour objectif de réaliser un projet d'amélioration de la logistique dans une entreprise 
de tri de cartons contenant des produits. Il s'agit d'un système RFID qui améliore le suivi des commandes 
des clients en utilisant des étiquettes pour __identifier le contenu de chaque boîte__.  
La portée du projet comprend le développement de __modèles prédictifs__ et le traitement des données, ainsi que la 
création d'une __interface utilisateur__ pour lancer des processus et configurer des modèles prédictifs. 

---

L'équipe développe deux modèles différents pour résoudre ce problème. Le premier, le modèle analytique, est 
un programme algorithmique qui exécute certaines actions dans une séquence définie au préalable. Le second est 
le modèle d'apprentissage automatique qui crée son propre ensemble de règles pour atteindre l'objectif. Il est 
lié par des hyperparamètres qui peuvent être ajustés pour augmenter sa précision. Pour afficher les résultats 
de chaque modèle, il a été décidé d'utiliser un site Web hébergé localement à partir duquel le client peut 
tester différentes versions du modèle d'apprentissage automatique. L'équipe utilise Visual Studio qui permet 
de coder tout un projet avec différents langages tels que C#, Python, HTML et CSS.

---
En outre, le projet inclut des fonctionnalités permettant d'exécuter des calculs de modèles, de visualiser 
les résultats, d'enregistrer les sorties de simulation et de comparer les résultats. Le résultat affiché 
pour chaque méthode est l'accuracy qui est la précision. Donc le pourcentage de de réussite de prédiction.
Le tout à travers une interface graphique simple d'utilisation et intuitive.

---
### Comment installer et exécuter le projet
---

Pour Faire fonctionner le projet qui est une application web MVC, vous aurez besoin d'un ide tel que Microsoft
Visual Studio, car il y a différents languages qui interviennent tel que C#, Python, HTML et CSS. 
Ainsi que Flask qui est un framework qui servira à lire les scriptes python dans la solution. Il
faudra installer python et flask.
Sur Flask, il faudra entrer dans le terminal 'python flash_api_test.py' bien sur vous devez emprunter le chemin
du projet.

---
### Comment utiliser le projet
---

Après avoir ouvert tout le projet contenant les lignes de codes et avoir configurer flask. Vous pouvez démarrer
l'interface graphique en utilisant run sur les pages http. Dans le cas où vous voulez utiliser une méthode pour
visualiser le résultat de prédiction, vous aurez le choix entre la méthode analytique ou les méthodes prédictives.
La méthode anlytique n'a pas besoin de paramètres, car c'est un algorithme qui exécute des actions dans des séquences
définis. Pour le cas des méthodes prédictives utilisant le machine learning, vous aurez besoin de configurer les
hyperparamètres des algorithmes que vous avez choisis. En changeant les hyperparamètres le résultat sera différent.

---

Vous pourrez enregistrer vos résultats pour les revoir dans la partie sauvegarde.

---

Si vous voulez comparer plusieurs méthodes, vous devrez cliquer sur le bouton comparer dès le départ puis choisir 
quelles méthodes vous voulez comparer. Si ce sont des méthodes prédictives vous devrez choisir les hyperparamètres. 
Pour plus d'information sur les hyperparamètres, mettez votre curseur sur les noms des hyperparamètres. Finalement,
vous aurez un graphique comparant les méthodes.

---
### Licence
---
MIT License. Le projet a pour but d'être pédagogique et de s'entrainer sur de nouvelles méthodes de travail en équipe
tout en utilisant de nouveaux outils.
