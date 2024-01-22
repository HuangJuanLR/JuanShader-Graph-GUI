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

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace JuanShaderEditor
{
	public class ContainerDrawer : IUniversalDrawer
	{
		private IUniversalDrawer container;

		private int level;
		private string data;
		private List<IUniversalDrawer> drawers;

		public int Level => level;

		public bool Containable => true;
		
		public IUniversalDrawer Container => container;

		public ContainerDrawer()
		{
			drawers = new List<IUniversalDrawer>();
		}

		public void Init(string data)
		{
			this.data = data;
		}
		
		public void Add(IUniversalDrawer drawer)
		{
			drawer.SetContainer(this);
			drawers.Add(drawer);
		}
		
		public void SetContainer(IUniversalDrawer container)
		{
			level = container.Level + 1;
			this.container = container;
		}

		public void Draw(MaterialEditor editor, Material material)
		{
			for (var i = 0; i < drawers.Count; i++)
			{
				drawers[i].Draw(editor, material);
			}
		}
	}
}