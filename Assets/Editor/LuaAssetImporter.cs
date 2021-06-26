
using UnityEngine;
using System.IO;
using UnityEditor.AssetImporters;

namespace LuaCustomAssetEditor
{
    [ScriptedImporter(1, "lua")]
    class LuaAssetImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var assetIcon = AssetDatabaseEx.LoadFirstAssetByFilter<Texture2D>("lua-file-icon");

            var luaScript = new TextAsset(File.ReadAllText(ctx.assetPath));
            ctx.AddObjectToAsset("LuaScript", luaScript, assetIcon);
            ctx.SetMainObject(luaScript);
        }
    }
}