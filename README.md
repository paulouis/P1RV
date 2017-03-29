PROJET P2RV sur la base du projet Archiverse de Mr Jacob Hamman. 

Le branche principale (Master) correspond au projet Solo c'est à dire sans le collaboratif, pour télécharger le projet unity associé à la version collaborative, assurez vous de vous être placé dans la branche "Tests" avant d'effectuer les étapes suivantes.


Instructions pour la mise en place du projet Unity à partir du Repo GITHUB (à ne faire qu'une fois puis normalement les Mise à jour du repo par Git ne poseront pas de problème car ne concerneront que quelques fichiers à chaque fois) :

1) Télécharger ou cloner le répertoire P1RV_CLONE 

2) faites en une copie quelque part (on va en avoir besoin à la fin) 

3) Aller sur : https://developer.leapmotion.com/unity#100 et télécharger les packages Unity suivants :
   - Unity Core Assets
   - Leap Motion Interaction Engine
   - Attachments Module
   - UI Input Module
   - Hands Module
   
4) Ouvrir une scène (P1RV.unity) dans le dossier asset et laisser Unity importer tous les fichiers

5) il y a beaucoup d'erreurs, c'est normal, Unity aime pas les packages Leap motion et il faut tous les réimporter

6) ouvrir et importer tous les packages Unity téléchargés directement dans votre projet (une petite fenêtre s'ouvre et il faut cliquer sur "import".

7) fermer unity et prenez votre copie du répertoire (étape 2) et Copier/Coller tout le contenu dans votre repo Git initial, ouvrez à nouveau unity et laisser le importer à nouveau.


En fait ce qui se passe, c'est que des conflits apparaissent lorsque on ne fait que copier des assets Leap Motion sans utiliser les Packages Unity dispo sur leur site. Du coup quand on démarre un projet à partir de mon repo git, il faut réimporter tous ces packages. De plus, j'ai eu besoin de modifer certains des assets de Leap motion, d'où le fait de réimporter une deuxième fois tout le repo Git.


* La documentation Arduino ainsi que les scripts associés au déplacement sont fournis dans la branche principale dans le dossier "Arduino"  
