# Configuration minimale 
- Processeur : Processeur de 1 GHz ou plus rapide
- RAM : 1 gigaoctet (Go) pour système 32 bits ou 2 Go pour système 64 bits
- Espace sur le disque dur : 1 Go pour le programme et l'enregistrement des informations de sauvegardes et des logs
- Carte graphique :	DirectX 9 ou version ultérieure avec pilote WDDM 1.0

# Emplacement par défaut logiciel
```
Projet Programmation Système
│   README.md
│   file001.txt    
│
└───ConsoleProject
│   │   file011.txt
│   │   file012.txt
│   │
│   └───Controller
│   │   │   InterfaceLanguage.cs
│   │   │   InterfaceSaveType.cs
│   │   │   LaunchProgram.cs
│	│	|	SelectLanguage.cs
│	│	|
│	│	Model
│   │   │   Context.cs
│   │   │   DBjson.cs
│   │   │   Logs.cs
│	│	│	SaveWork.cs
│	│	│	States.cs
│	│	│	WriteLogs.cs
│	│	|	WriteStates.cs
│	│	│
│	│	└───Strategies
│	│	│	│   AllTheSavesStrategy.cs
│	│	│	│   EnglishStrategy.cs
│	│	│	│   LogsExecuteSaveOnCreation.cs
│	│	│	│	FrenchStrategy.cs
│	│	│	│	SpecificSaveStrategy.cs
│	│	────
│	│	View
│   │    │   file111.txt
│   │    │   file112.txt
│   │    │   ...
│   │
│   
│   
```

# Emplacement des fichiers de configuration
Fichier config 'bdd.json' : C:\\bdd.json
Fichier logs 'logs.json' : C:\\logs.json
Fichier statut 'states.json' :C:\\states.json