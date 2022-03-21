using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");
            Gl.glClearColor(1, 1, 0.8f, 1);
            float[] verts = { 
            0.5f,0.3f,0,  //0
            0.25f,0f,0, 
            -0.5f,0.3f,0,  //1
            0.25f,0f,0, 
            0.0f,1.0f,0,  //2
            0.25f,0f,0, 
            /////////////////
            /////////////////
            0.35f,0.3f,0, //3
            0.8f,0.7f,0.4f,
            -0.35f,0.3f,0, //4
            0.8f,0.7f,0.4f,
            0.35f,-0.7f,0, //5
            0.8f,0.7f,0.4f,
            -0.35f,0.3f,0, //6
            0.8f,0.7f,0.4f,
            0.35f,-0.7f,0, //7
            0.8f,0.7f,0.4f,
            -0.35f,-0.7f,0,//8
            0.8f,0.7f,0.4f,
            /////////////////
            /////////////////
            0.3f,0.97f,0,  //9
            0.3f,0.3f,0.3f,
            1.0f,-0.7f,0, //10
            0,0,0,
            -1.0f,-0.7f,0, //11
            0,0,0,
            /////////////////
            /////////////////
            0.29f,0.2f,0,  //12
            0,0,0,
            0.29f,-0.01f,0,   //13
            0,0,0,
            /////////////////
            /////////////////
            0.18f,0.2f,0,  //14
            0,0,0,
            0.18f,-0.01f,0,   //15
            0,0,0,
            /////////////////
            /////////////////
            -0.2f,0.2f,0,  //16
            0,0,0,
            -0.2f,-0.01f,0,   //17
            0,0,0,
            /////////////////
            /////////////////
            -0.3f,0.2f,0,  //18
            0,0,0,
            -0.3f,-0.01f,0,   //19
            0,0,0,
            /////////////////
            /////////////////
            -0.2f,0.2f,0,  //20
            0,0,0,
            -0.3f,0.2f,0,   //21
            0,0,0,
            /////////////////
            /////////////////
            -0.2f,0.14f,0,  //22
            0,0,0,
            -0.3f,0.14f,0,   //23
            0,0,0,
            /////////////////
            /////////////////
            -0.2f,0.05f,0,  //24
            0,0,0,
            -0.3f,0.05f,0,   //25
            0,0,0,
            /////////////////
            /////////////////
            -0.2f,-0.01f,0,  //26
            0,0,0,
            -0.3f,-0.01f,0,   //27
            0,0,0,
            /////////////////
            /////////////////
             0.29f,-0.01f,0,  //28
            0,0,0,
            0.18f,-0.01f,0,   //29
            0,0,0,
            /////////////////
            /////////////////
             0.29f,0.14f,0,  //30
            0,0,0,
            0.18f,0.14f,0,   //31
            0,0,0,
            /////////////////
            /////////////////
             0.29f,0.2f,0,  //32
            0,0,0,
            0.18f,0.2f,0,   //33
            0,0,0,
            /////////////////
            /////////////////
             0.29f,0.05f,0,  //34
            0,0,0,
            0.18f,0.05f,0,   //35
            0,0,0,
            /////////////////
            /////////////////
            0.3f,0.9f,0,  //36
            0.25f,0,0,
            0.2f,0.9f,0,   //37
            0.25f,0,0,
            /////////////////
            /////////////////
             0.2f,0.3f,0,  //38
            0.25f,0,0,
            0.3f,0.3f,0,   //39
            0.25f,0,0,
            /////////////////
            /////////////////
             0.25f,0.95f,0,  //40
            0.3f,0.3f,0.3f,
            /////////////////
            /////////////////
             0.27f,0.96f,0,  //41
            0.3f,0.3f,0.3f,
            /////////////////
            /////////////////
            0.23f,0.98f,0,  //42
            0.3f,0.3f,0.3f,
             /////////////////
            /////////////////
            -0.08f,-0.099f,0,  //43
            0,0,0,
            0.062f,-0.099f,0,   //44
            0,0,0,
             /////////////////
            /////////////////
             0.062f,-0.7f,0,  //45
            0,0,0,
            -0.08f,-0.7f,0,   //46
            0,0,0,
             /////////////////
            /////////////////
             0.04f,-0.32f,0,  //47
            0.5f,0,0,
             /////////////////
            /////////////////
            0.68f,0.2f,0,     //48
            0,0,0,
            0.68f,-0.7f,0,   //49
            0,0,0,
             /////////////////
            /////////////////
            0.7f,0.1f,0, //50  0.7
            0,0.6f,0,
            0.5f,0.1f,0, //51   0.5 (-0.2)
            0,0.6f,0,
            0.55f,0.2f,0, //52   0.55 (-0.15)
            0,0.6f,0,
            0.7f,0.3f,0,  //53    0.7 (-0)
            0,0.6f,0,
            0.85f,0.2f,0,  //54   0.85  (+0.15)
            0,0.6f,0,
            0.9f,0.1f,0,   //55   0.9   (+0.2)
            0,0.6f,0,
             /////////////////
            /////////////////
            -0.68f,0.2f,0,     //56
            0,0,0,
            -0.68f,-0.7f,0,   //57
            0,0,0,
             /////////////////
            /////////////////
            -0.7f,0.1f,0, //58  0.7
            0,0.6f,0,
            -0.5f,0.1f,0, //59   0.5 (-0.2)
            0,0.6f,0,
            -0.55f,0.2f,0, //60  0.55 (-0.15)
            0,0.6f,0,
            -0.7f,0.3f,0,  //61    0.7 (-0)
            0,0.6f,0,
            -0.85f,0.2f,0,  //62  0.85  (+0.15)
            0,0.6f,0,
            -0.9f,0.1f,0,   //63   0.9   (+0.2)
            0,0.6f,0,
             /////////////////
            /////////////////
            1.0f,-0.9f,0, //64
            0,0,0,
            -1.0f,-0.9f,0, //65
            0,0,0,
            ////////////////
            ////////////////
            0.73f,0.2f,0,     //66
            0,0,0,
            0.73f,-0.7f,0,   //67
            0,0,0,
            ///////////////
            //////////////
            -0.73f,0.2f,0,     //68
            0,0,0,
            -0.73f,-0.7f,0,   //69
            0,0,0
            //////////////
            /////////////
            };
            vertexBufferID = GPU.GenerateBuffer(verts);
        }
        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();
            Gl.glEnableVertexAttribArray(0);//POSITION_ID
            Gl.glEnableVertexAttribArray(13);//Color_ID
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, IntPtr.Zero);//For Positions
            Gl.glVertexAttribPointer(13, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, (IntPtr)(sizeof(float)*3));//For Colors
            ///////////////////////////
            //// Draw your primitives !
            Gl.glPointSize(3);
            //1-TRIANGLES
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 3, 6);
            
            //2-POINTS
            Gl.glDrawArrays(Gl.GL_POINTS, 9, 1);
            Gl.glDrawArrays(Gl.GL_POINTS, 40, 1);
            Gl.glDrawArrays(Gl.GL_POINTS, 41, 1);
            Gl.glDrawArrays(Gl.GL_POINTS, 42, 1);
            Gl.glDrawArrays(Gl.GL_POINTS, 47, 1);
           
            //3-LINES
            for (int i = 10; i <= 34;i+=2 )
            {
                Gl.glDrawArrays(Gl.GL_LINES, i, 2);
            }
            Gl.glDrawArrays(Gl.GL_LINES, 48, 2);
            
            //4-LINE_STRIP
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 56, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 64, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 66, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 68, 2);
            
            //5-LINE_LOOP
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 36, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 43, 4);
            
            //6-TRIANGLE_FAN
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 50, 6);
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 58, 6);
            ///////////////////////////////////////////
            Gl.glDisableVertexAttribArray(0);
            Gl.glDisableVertexAttribArray(13);
        }
        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}