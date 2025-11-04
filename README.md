# Eden's Project

###Genre:  gestion

<ins> PITCH:</ins>
Au commencement, Dieu créa le ciel et la terre. Puis il vous créa, vous, le Créateur, son subordonné. Entre les hommes, les créatures mythologiques, les demi-dieux et la nature,  fondez votre domaine comme vous l’entendez et laissez le destin faire le reste si dieu le veut  !
CONTRÔLES

CONTRÔLES DU JOUEUR (Clavier):

ZQSD, Haut Bas Gauche Droite ou mettre la souris sur les bords de l’écran : déplacer la caméra.

-	E/A: faire pivoter la caméra. 

clic gauche : Réaliser l’action / Interagir

roulette: Zoomer.

Barre d’espace: Recentrer la caméra sur l’objet sélectionné.

CAMÉRA

La caméra est une caméra STR classique.
Les limites de la caméra en termes de déplacement sont les bordures propres à chaque niveau.
Pour le pivot de la caméra, il se fait par rapport à la projection du centre de l’écran sur le sol.
Lorsqu’on recentre la caméra sur l’objet sélectionné ,elle s’adapte en termes de hauteur et de distance par rapport à celui-ci.
Si on désélectionne l’objet, elle retrouve la hauteur et la distance qu’elle avait avant de s’adapter à l’objet, mais en gardant la même position.
LA ROUE DU CRÉATEUR
La roue du créateur est une interface à laquelle on peut accéder en appuyant sur E.
C’est à travers elle que le joueur peut façonner le monde comme il l'entend grâce à différentes fonctionnalités:

1 Eléments naturels :
Créer des arbres
Créer des plantes
Créer des pierres
Modifier sol
Génération:
Pour générer ces éléments, le joueur dispose d’un spawner modelable (voir exercice spawn tool) qui permet de générer en masse en clippant au terrain.

2 Architecture:
Pylones
Hôtels
Temples
Génération:
Pour générer ces éléments, le joueur dispose d’un spawner modelable (voir exercice spawn tool) qui permet de générer à l’unité en clippant au terrain.
le terrain doit avoir une surface plane correspondante à la surface nécessaire pour l’architecture en question.

3 Êtres vivants:
Créatures terrestres
Humains
Créatures Mythologiques
Génération:
Pour générer ces éléments, le joueur dispose d’un spawner modelable (voir exercice spawn tool) qui permet de générer à l’unité ou en masse en clippant au terrain.
                  
4 Relief :
Modifier la hauteur/profondeur.
Génération:
Applique une déformation sur le terrain.

5 Point d’eau:
Eau de source
Eau de Mer
Génération:
Applique applique un layer sur le terrain.

DÉROULEMENT

Le jeu commence dans le menu principal et vous demande de créer une nouvelle partie ou de quitter.
 
En sélectionnant la nouvelle partie, vous pouvez choisir la taille de votre monde. 

Le jeu commence avec une map complètement déserte, en l’an 0 , dans laquelle vous devrez commencer à essayer de rendre la map habitable.

Pour cela, vous devez utiliser les outils de création pour sculpter le monde comme vous l’entendez.

Quand certains critères sont remplis, des humains ou des animaux commencent à apparaître:

Par exemple, si le joueur met 20 % de forêt dans son monde, les sangliers vont apparaître.

En gros, la faune, la flore, les architectures ou les éléments naturels que vous générerez tout au long de la partie seront en fonction de conditions d’apparition.

Le fait d’avoir un nouvel élément qui apparaît dans votre jardin vous permet de le générer grâce à la roue du créateur par la suite.

Libre a vous d’essayer de faire de votre jardin un havre de paix, ou l’enfer sur terre.


CONDITIONS D’APPARITION

Les conditions d’apparitions sont prédéfinies pour chaque objet du jeu, et lorsque celles- ci sont remplies, cela génère un nombre prédéfinie de l’objet en question.

Les facteurs liés au conditions d’apparition sont:

le taux de présence d’un objet en %
une condition précise
une année dépassée



LES ÊTRES VIVANTS

Les êtres vivants sont des entités autonomes qui parcourent votre monde.

Elles peuvent soit apparaître  en fonction des facteurs qui composent votre jardin, soit par le biais de la roue de la création.

Caractéristiques: 

Ils sont composés de certaines caractéristiques innées:

Habitat:
Lieu ou cet être vit (désert, forêt, montagne enneigées)

Nourriture:
	De quoi se nourrît cet être.

-Nature:
	Vers quel nature tendcet être vivant

Durée de vie:
	Combien de temps vie cet être en moyenne.

Ces caractéristiques sont à prendre en compte si on veut gérer l’équilibre et la bonne évolution des êtres dans le jardin. Elles ne peuvent pas être modifiées.
Et ils sont aussi composés de caractéristiques de bien être, qui sont les besoins au moment T d’un individu spécifique:

La faim:
Elle augmente au fur et à mesure après que l’être se soit nourri.

La soif:
Elle augmente au fur et à mesure après que l’être se soit déshydraté.

L'âge:
	Augmente au fur et à mesure.


L’état Immunitaire:
Est ce que cet être est en bonne santé, blessé ou malade ? 
ce critère dépend de:
-La joie.
-L’habitat.
-La faim.
-La soif.
-L'âge.
-Tempérament.

La joie
dépend de la congruence entre ses caractéristiques innées et de sa réalité.
dépend aussi de:
- La faim.
- La soif.
- L’état immunitaire.
- Tempérament.

Tempérament
Cette caractéristique est aléatoire à la naissance.

Les être humains et les demi-dieux ont une caractéristique supplémentaire, qui est:
 
La soif de grandeur
dépend de:
-L'âge.
-Le Tempérament.

Ces caractéristiques peuvent varier d’un être vivant à l’autre en fonction de son environnement, et c’est elles qui vont influer sur le comportement de l’être vivant.

Chaque être vivant dispose d’un périmètre de détection, en fonction de son type, qui définit si les conditions liées au caractéristiques innées sont bonnes ou pas au moment T. C’est grâce à ce périmètre que certaines conditions d’apparitions sont remplies.











Influences:

Les êtres vivants sont le fruit de leur environnement, et leur vie devient unique en fonction de leur vécu. Ils peuvent influer sur la flore environnante, autant que la flore peut influer sur eux.

(Exemple : On créer un meute énorme de lapin au milieu de l’océan, peut probable qu’il y ait des survivants.  

 Ou alors , on créer cette même meute de lapin gigantesque dans un petit village paisible au bord d’une colline. 2 jours après, une guerre a débuté entre ce petit village et la horde de lapin pour s’approprier les ressources environnantes.)

Les caractéristiques de bien être varient en fonction de l’environnement.


Comportement:

Les êtres vivants Agissent en fonction de leur caractéristiques:

Si la faim est élevée, l’être va se mettre en état de recherche de nourriture. 
même principe pour la soif.

Si la soif de grandeur est haute, ces être peuvent créer des grandes choses, comme des structures, des communautés, de magnifiques jardins, des créatures…

Les être humains et les Demi-dieux influent beaucoup sur leur environnement par leur comportement.

Si les bonnes civilisations sont entourées de la bonne faune ou de la bonne flore, ou font la rencontre d’autres civilisations ou même de demi-dieu, cela peut générer des nouveaux êtres vivants, des nouvelles structures etc…









LES ÉLÉMENTS NATURELS & LES ARCHITECTURES

Ce sont les éléments naturels qui vont être à la base de la faune et de la flore. En changer la composition peut bouleverser des facteurs cruciaux.

Le retrait ou l’abondance de certains éléments naturels peut faire disparaître ou surpeupler une certaine espèce.

Pour les architectures, chaque civilisation d’humain ont leur architectures, qu’ils construisent dans certaines conditions.

les caractéristiques innées de ces objets sont:

Habitat
Durée de vie

et la seule caractéristique de bien être est l'âge pour les architectures et les pierres.

Pour les plantes, l’âge et l’état immunitaire.

A rajouter pour le proto:

la liste des éléments du jeu pour faire un premier jet.

l’interface, comment accéder à chaque outil.
