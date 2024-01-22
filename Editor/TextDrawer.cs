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
	public class TextDrawer : IUniversalDrawer
	{
		private IUniversalDrawer container;
		
		protected int level;
		
		public int Level => level;

		public bool Containable => false;
		
		public IUniversalDrawer Container => container;

		private string title = "";
		private string type = "";

		public void Init(string data)
		{
			string[] dataArray = data.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			if (dataArray.Length == 2)
			{
				title = dataArray[0];
				type = dataArray[1].Trim().ToLower();
			}
			else
			{
				title = data;
			}

			string[] titleSep = title.Split(new[] { "#n" }, StringSplitOptions.RemoveEmptyEntries);

			title = "";
			foreach (var line in titleSep)
			{
				if (line != titleSep[titleSep.Length - 1])
				{
					title += line.Trim() + "\n";
				}
				else
				{
					title += line.Trim();
				}
			}
		}
		
		public void Add(IUniversalDrawer drawable)
		{
		}
		
		public void SetContainer(IUniversalDrawer container)
		{
		}

		public void Draw(MaterialEditor editor, Material material)
		{
			if(type == "info")
			{
				EditorGUILayout.HelpBox(title, MessageType.Info);
			}
			else if(type == "warning")
			{
				EditorGUILayout.HelpBox(title, MessageType.Warning);
			}
			else if (type == "error")
			{
				EditorGUILayout.HelpBox(title, MessageType.Error);
			}
			else
			{
				EditorGUILayout.LabelField(title, ShaderGUIStyle.TextFolder);
			}
			
		}
	}
}