# cloud-tomadachi
Cloud formation template generated avatar


1. Read cloudformation template
2. Extract features
3. Seed avatar generator
4. Render avatar as image




## Avatar Generator

### Collect CF template features
Extract raw features from known CF templates using the git repo from aws's solution CF examples and from the direct aws "services" examples provided. the model would be trained to robustly understand how to extract the services that are in the template and the complexity of each of the services. 

- Collect CF templates for training a model
    - https://github.com/awslabs/aws-cloudformation-templates/tree/master/aws/services
    - https://github.com/awslabs/aws-cloudformation-templates/tree/master/aws/solutions

Using the service list and complexity wieghts the next phase can be taken to map it into an imaginary environment with physical properties. 

### Map the features into a 'Physical' Environment

Modify creature generation based on environment designed in the cloud : 
Imagine the cloud environment as a real environment with physical attributes , then use that physical attributes to design a creatures physiology to adapt to such environment. 

An arbitrary example for environment feature mapping :

| Service |  Terrain | Fauna | Climate | Exposure | Noise | Light | BioDiversity  |
|---------|----------|-------|---------|----------|-------|-------|---------------|
| Lambda  |  -2      |  +2    |  -2    |   +3      |  +4     | +2      | -3              |
| EC2     |  +3      |  -1    |  +3    |   -1     |   0    |   -1    |    +3           |
| ECS     |  -1      |   0    |  +1    |   +1       |  +1     |  +1     |   -1            |
| Fargate |  -1      |   0    |  -1    |   +1      |   +1    |    -1   |      -2         |
| IoT     |   0      |  +1    |  -1    |   -1     |   0   |   0    | +2      | -2 |

The table shows how the dimensions can be created for an environment given different services 
inside the CF template. This can be tweaked and modified based on new services and the interpretation of the 
abstraction layer. (A bit of an artistic license)

The resulting feature mapping would result in an environment a creature can be created for. 
That means a model can be used to take environment features and output a creature description. 

### Generate a Creature for the Environment


1. The mapped environment space should be squashed into an "origin" based on shape of environment matrix. 

```js
    origin = ["the depths of hell", "a coven of witches", "unspeakable evil", "the old gods", "a mysterious cult", "a cursed swamp", "a forgotten land", "a yawning hellmouth", "a horrifying machine", "a dreaming god", "the ocean depths", "fear itself", "outer space", "a secret government agency", "alien beings", "unstoppable nanobots", "a shadowy cabal", "a talking statue", "a flying city", "a fetid sewer", "the tomb of an ancient king", "a subterraneous city", "a fissure in the Earth's crust", "a gelatinous egg"];
```
    
2. The origin type should then allow a subset of "creature" types. additional "body parts" or "scars" can be generated from  dates or number of descriptive tags, in teamplate. 

```js
    creatureType = ["man", "woman", "ghost", "bird", "dragon", "salamander", "lizard", "troll", "golem", "wolf", "basilisk", "cat", "snail", "fish", "squid", "blowfish", "crab", "bear", "viking", "tarantula", "robot", "whale", "goblin", "owl", "minotaur", "cyclops", "child", "goat", "shark", "crocodile", "bat", "moth", "centipede"];

    bodyPart = ["head", "arms", "fingers", "toes", "legs", "elbows", "tail", "claws", "tentacles", "knees", "face", "bones", "teeth", "hair", "tongue", "wings"];
```

3. The complexity vector should provide an adjective and a action feature for the creature

```js
    adjective = ["gigantic", "spiny", "slimy", "twisted", "shimmering", "scaly", "wrinkled", "flaming", "crystal", "enlongated", "shrunken", "mummified", "muscular", "petrified", "skeletal", "knife-like", "corpulent", "leathery", "hairy", "barnacle encrusted", "shadowy", "incorporeal", "iron", "clay", "ashen", "stone", "humanoid", "mechanical", "feathered", "venomous", "glowing", "rotting", "sweaty", "elegant", "beautiful", "origami", "weeping", "silvery", "golden", "peeling", "velvet", "tattooed", "gelatinous", "shriveled"];

    action = ["wriggles", "spins", "swings", "lashes out with", "haunts the living with", "shakes", "tore off", "armored", "burned", "painted", "sharpened", "electrified", "shoots fire from", "emits radiation from", "sprouts tiny, reaching arms from", "crawls with worms from", "stands on", "speaks using", "sewed on", "wrapped and bandaged", "flies using", "drips violet ichor from", "has an extra face on", "inverts"];
```

Copying monster generator snippet from *[devfilipesales/DnD-Monster-Generator](https://devfilipesales.github.io/DnD-Monster-Generator/)*. Using the snippet as a way to convert the raw features from the CF template into an 
artistic abstract of features to design the final svg image with a renderer.


# More ideas on mapping services

A rubric for each service can  be qualitatively designed to convert it into physical locations for generation of creature physiology. OR , a very well used rubric for converting things that are technical into abstract can be used. The MTG color wheel! I was inspired by https://humanparts.medium.com/the-mtg-color-wheel-c9700a7cf36d . His insight on the deepness of this wheel is incredible. Lets attempt to stretch it into the realm of amazon web services. 

He creates this wonderful pentagram of correlation into these dimensions. 

![](https://miro.medium.com/max/700/1*Yf59VVey9kS6yuHo5Cs41g.png)


By utilizing this mapping we can interpret the features of any aws service and 
overlay a qualitative rubric to apply rankings for each of these dimensions. 
Normalizing the rubric from 1-10 any user can add a new service to the app
by filling out the sliding scale based on the following description for each 
dimension as it pertains to AWS. 


| MTG       |        | AWS |    
|---------|----------|-----|
| Order | Chaos      | Simplicity (Removes TechDebt) vs. Complexity (Adds TechDebt) |
| Group | Individual | Ubiquitous Usage vs. Specialized Use-case|
| Nature | Nurture   | Managed Service vs. Customer Maintained|
| Emotion | Reason   | Insights vs. Operations |
| Preservation | Exploitation| Forces Cloud Native vs. Enables Cloud Agnostic|


The ability to map AWS services to MTG color wheel allows for the formation of the creature by using MTG environments for each color. 

The types of creatures attracted to the different types of colors can by using the Scryfall api

Example 1: a list of white creatures can be found by using "c:w" and "t:creature" in the api.  https://api.scryfall.com/cards/search?q=c:w%20t:creature

Example 2: a list of creatures that are at least white and blue but not red , creatures can be found by using "t:creature" in the api.  https://api.scryfall.com/cards/search?q=color>%3Duw+-c%3Ared%20t:creature


So the color wheel gets us to a defined webservice. Now a series of webservice and the interactions between them will provide a collection of webservices. The collection and its latent interactions can be squashed into a single color wheel using with weighted colors. The new color wheel ranking can then be normalized and used to choose a creature from the skycraft api. 

These MTG creatures are nothing like tomagatchi's . The cute cuddly creatures that help you sleep at night while the cloud team deploys your stack into production. So in order to get to the next stage I suggest using the color wheel and the MTG creatures as something like "DNA" . A small creature destined to take on the characteristics of the MTG character. 

The MTG creatures come with flavor text and color palletes, and all kinds of intersting things like toughness and power. These are additional features that can help extract a more unique creature for the environment. 


On an initial load, if the architecture is very young and the cloudformation templates are the first to be built. Then I should be able to search for creatures of a certain color and power.  As the architecture grows in complexity and age i can increase the search to higher power levels and toughness. 

A MTG creature that is returned is used to model the cloud cretaure by leveraging the metadata/flavortext/name/effects of that MTG creature. 

## Translating from MTG Creature to Cloud Creature

A big question was what would be the anatomy of cloud creatures once i have translated the cloud into known types of land. 
I took a glance at this [document on anatomy of animals](https://craftx.org/sites/all/themes/craft_blue/pdf/Anatomy_and_Physiology_of_Animals.pdf). I learned about the skeletal structures and locomotion and how the anatomy is designed for the environment. The generalized environments provided MTG , is not going to be enough. SO , i need to create a sliding scale between each of the MTG terrains associated with the color wheel. Each extreme anatomy needs to be "tweened"
so by taking adaptations and using the extreme of that adaptation i can map it to the MTG colorwheel dichotomies. This will provide adaptations that are related to the continuum of the cloud creature color measurements. 


| Color 	| Basic Land 	| Anatomy Locomotion 	| Anatomy fore Limbs 	| Mouth        	| skin                                      	| Teeth       	| Art Style 	| Muscle                                  	|
|-------	|------------	|--------------------	|--------------------	|--------------	|-------------------------------------------	|-------------	|-----------	|-----------------------------------------	|
| White 	| Plains     	| Unguligrade        	| 4 legs             	| herbivore    	| rough short hair,pastel colors,pattterned 	| Tusks       	| Broad     	| Lean arms and thick legs                	|
| Blue  	| Island     	| feathers           	| wings/arms         	| pescatarian  	| thin cloroful,scaley,feathery             	| Beak        	| Smooth    	| Grip/Bite                               	|
| Black 	| Swamp      	| Fins               	| tentacles          	| scavengers   	| scabbed, slimey,gooey,wrinkley            	| sharp teeth 	| Jagged    	| Minimal, almost skeletal                	|
| Red   	| Mountain   	| Digitigrade        	| short 4 legs       	| carnivore    	| coarse hair, dark or light                	| horns       	| Agile     	| Compact , Lean legs, small but powerful 	|
| Green 	| Forest     	| Plantigrade        	| 4 legs             	| herbivore    	| fluffy,thick,furry,rough                  	| antlers     	| Strong    	| Large muscle mass, Fatty                	|





Testing the idea here is a wierd looking pokemon :
- it looks like somekind of mokey bird hybrid. 
- so through some backward induction , it would of been somewhere between white and blue since it embodies the artstyle of smooth and broad, lean arms and thick leg with grip, it has more of a beak than a tusk. it has some colorgul patterned hair, looks like a herbivore and has arms instead of wings but has 4 limbs. 

![](https://oyster.ignimgs.com/mediawiki/apis.ign.com/pokemon-switch/e/ea/Grookey.jpg =100x)

Some issues:
- The breakdown needs to be though out more, since there are ambiguities in the muscle, and anatomy dimensions. This means that these artistic features need to have an intensity metric that balances how much of it becomes pronounced or not. This could come from the intensity of the color not just the ranking of the color. Where the intensity is derived from the overlaid webservice rankings in a set of services inside an architecture.

> Note: I would need to understand how to apply these artistic components to a poseable skeleton to get cute poses like this funky looking monkeybird thing. 

