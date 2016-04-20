# Unity-Custom-Imports
Use Unity Assets Processor to set importing rules, improving the asset pipeline, and avoiding time consuming manual changes. 

#Models#

Importing a model to a path conatining

**Model** will changes its settings. 

**Static** will remove the animations and create extra uv for lightmaping. 

**LowPoly** will calculate the normals to 0,  it gives a low poly effect. 

#Sprites#

Importing a texture to a path containging **Sprites** will set some features.

Adding _RC'#1'x'#2' to the sprite will auto slice the sprite in '#1' rows and '#2' columns.

Example

awasomeSprite_RC4x6. 

Also the sprite packer will be set as the parent folder. 

#Oficial documentation#

http://docs.unity3d.com/ScriptReference/AssetPostprocessor.html


