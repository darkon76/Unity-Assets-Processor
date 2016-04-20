using UnityEditor;

public class ModelProcessor : AssetPostprocessor
{
    private void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        if (modelImporter != null)
        {
            if (assetPath.Contains("Models"))
            {
                modelImporter.addCollider = false;
                modelImporter.importBlendShapes = false;
                modelImporter.optimizeMesh = true;
                modelImporter.meshCompression = ModelImporterMeshCompression.High;

                #region Static

                if (assetPath.Contains("Static"))
                {
                    modelImporter.generateSecondaryUV = true;
                    modelImporter.importAnimation = false;
                    modelImporter.animationType = ModelImporterAnimationType.None;
                }
                #endregion Static

                #region LowPoly

                if (assetPath.Contains("LowPoly"))
                {
                    modelImporter.importNormals = ModelImporterNormals.Calculate;
                    modelImporter.normalSmoothingAngle = 0;
                }
                #endregion LowPoly
            }
        }
    }
}