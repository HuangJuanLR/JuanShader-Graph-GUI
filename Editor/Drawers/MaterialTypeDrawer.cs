/*
Copyright <2023> <HuangJuanLr>

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the “Software”), to deal in
the Software without restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using UnityEditor;
using UnityEngine;

namespace JuanShaderEditor
{
	public class MaterialTypeDrawer : MaterialPropertyDrawer
	{
		public enum MaterialType
		{
			Standard = 0,
			Anisotropic = 1,
			Iridescence = 2,
			SubsurfaceScattering = 3,
			Translucent = 4,
		}

		public override void OnGUI(Rect position, MaterialProperty property, String label, MaterialEditor materialEditor)
		{
			Material material = materialEditor.target as Material;
			MaterialType display = (MaterialType)property.floatValue;
			var value = property.floatValue;

			EditorGUI.BeginChangeCheck();
			
			display = (MaterialType)EditorGUI.EnumPopup(position, label, display);
			value = (float)display;

			if (EditorGUI.EndChangeCheck())
			{
				property.floatValue = value;
			}
		}
	}
}