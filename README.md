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


