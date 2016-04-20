using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpritePostProcessor : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        if (textureImporter == null)
        {
            return;
        }
        if (assetPath.Contains("Sprite"))
        {
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spritePixelsPerUnit = 16;
            textureImporter.mipmapEnabled = false;
            textureImporter.filterMode = FilterMode.Point;
            textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;

            #region SpritePacker

            string path = assetPath;
            path = path.Replace("Assets/Sprites/", "");
            string[] pathSplit = path.Split('/');
            if (pathSplit.Length > 1)
            {
                textureImporter.spritePackingTag = pathSplit[0];
            }
            #endregion SpritePacker
        }
    }

    #region PostProcess

    private void OnPostprocessTexture(Texture2D texture)
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        if (textureImporter == null)
        {
            return;
        }
        string[] path = assetPath.Split(new char[] { '/', '\\' });
        string fullFileName = path[path.Length - 1];
        string[] ext = fullFileName.Split(new char[] { '.' });
        string fileName = ext[0];
        if (fileName.Contains("_CR"))
        {
            string[] split = fileName.Split(new string[] { "_CR" }, StringSplitOptions.None);
            fileName = split[0];
            string[] code = split[1].Split('x');
            int width = texture.width / int.Parse(code[0]);
            int height = texture.height / int.Parse(code[1]);

            List<SpriteMetaData> newData = new List<SpriteMetaData>();
            for (int i = 0; i < texture.width; i += width)
            {
                for (int j = texture.height; j > 0; j -= height)
                {
                    SpriteMetaData smd = new SpriteMetaData();
                    smd.pivot = new Vector2(0.5f, 0.5f);
                    smd.alignment = 9;
                    smd.name = fileName + " " + (texture.height - j) / height + "_" + i / width;
                    smd.rect = new Rect(i, j - height, width, height);

                    newData.Add(smd);
                }
            }

            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            textureImporter.spritesheet = newData.ToArray();
        }
    }

    #endregion PostProcess
}