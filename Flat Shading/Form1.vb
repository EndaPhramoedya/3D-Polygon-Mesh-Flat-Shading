Public Class Form1
    Dim graph As Graphics
    Dim bmp As Bitmap
    Dim vertices(10) As Vertex
    Dim edges(11) As Edge
    Dim surfaces(5) As Surface
    Dim center As Vertex
    Dim pr(3, 3) As Single
    Dim Translate(3, 3), Rotatex(3, 3), Rotatey(3, 3), Rotatez(3, 3) As Single
    Dim view(3, 3), screen(3, 3) As Single
    Dim dx, dy, dz, tetax, tetay, tetaz As Single
    Dim VS(10), VR(8) As Vertex
    Dim check1, check2 As Integer
    Dim checkL As Integer

    Dim ka, kd, Iamb, Idif, Itot As Single
    Dim Ia As Single = 0.1
    Dim IL As Single = 0.5
    Dim viewer As Vertex
    Dim lights As Vertex

    Dim myBrush As Brush
    'cari Vcenter, terapin ke smua surface
    'LS sama Vcenter kali matrix
    'Color= RGB(Itot, 0, 0) merah dsb

    Structure Vector
        Public i, j, k As Single
    End Structure

    Structure Edge
        Dim point1, point2 As Integer
    End Structure

    Structure Vertex
        Dim x, y, z, w As Single
    End Structure

    Structure Surface
        Dim vertex1, vertex2, vertex3, vertex4 As Integer
        Dim isVisible As Boolean
        Dim wrn As Color
    End Structure

    Sub SetVector(ByRef vector As Vector, ByVal x As Single, ByVal y As Single, ByVal z As Single)
        vector.i = x
        vector.j = y
        vector.k = z
    End Sub

    Sub SetColMat(ByRef Matrix(,) As Single, ByVal col As Integer, ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)
        Matrix(0, col) = a
        Matrix(1, col) = b
        Matrix(2, col) = c
        Matrix(3, col) = d
    End Sub

    Sub SetEdge(ByRef edge As Edge, ByVal n1 As Integer, ByVal n2 As Integer)
        edge.point1 = n1
        edge.point2 = n2
    End Sub

    Sub SetVertex(ByRef Vertex As Vertex, ByVal x As Single, ByVal y As Single, ByVal z As Single)
        Vertex.x = x
        Vertex.y = y
        Vertex.z = z
        Vertex.w = 1
    End Sub

    Sub SetSurface(ByRef mesh As Surface, ByVal m1 As Integer, ByVal m2 As Integer, ByVal m3 As Integer, ByVal m4 As Integer)
        mesh.vertex1 = m1
        mesh.vertex2 = m2
        mesh.vertex3 = m3
        mesh.vertex4 = m4
    End Sub

    Function MultiplyMat1(ByVal point As Vertex, ByVal M(,) As Single) As Vertex
        Dim result As Vertex

        result.x = (point.x * M(0, 0) + point.y * M(1, 0) + point.z * M(2, 0) + point.w * M(3, 0))
        result.y = (point.x * M(0, 1) + point.y * M(1, 1) + point.z * M(2, 1) + point.w * M(3, 1))
        result.z = (point.x * M(0, 2) + point.y * M(1, 2) + point.z * M(2, 2) + point.w * M(3, 2))
        result.w = (point.x * M(0, 3) + point.y * M(1, 3) + point.z * M(2, 3) + point.w * M(3, 3))

        result.x = result.x / result.w
        result.y = result.y / result.w
        result.z = result.z / result.w
        result.w = 1

        Return result
    End Function

    Function MultiplyMat2(ByVal M1(,) As Single, ByVal M2(,) As Single) As Single(,)
        Dim result(3, 3) As Single

        For row = 0 To 3
            For col = 0 To 3
                result(row, col) = (M1(row, 0) * M2(0, col)) + (M1(row, 1) * M2(1, col)) + (M1(row, 2) * M2(2, col)) + (M1(row, 3) * M2(3, col))
            Next
        Next

        Return result
    End Function

    'functions to calculate cos
    Function cos(ByVal x As Single) As Single
        Return Math.Cos(x * (Math.PI / 180))
    End Function

    'functions to calculate sin
    Function sin(ByVal x As Single) As Single
        Return Math.Sin(x * (Math.PI / 180))
    End Function

    'functions to calculate dot product
    Function DotProductof(ByVal V1 As Vector, ByVal V2 As Vector) As Single
        Return V1.i * V2.i + V1.j * V2.j + V1.k * V2.k
    End Function

    'functions to calculate cross product
    Function CrossProductof(ByVal V1 As Vector, ByVal V2 As Vector) As Vector
        Dim result As New Vector
        result.i = (V1.j * V2.k) - (V1.k * V2.j)
        result.j = (V1.k * V2.i) - (V1.i * V2.k)
        result.k = (V1.i * V2.j) - (V1.j * V2.i)
        Return result
    End Function

    'functions to calculate Iambient
    Function ambient(ByVal ka As Single, ByVal Ia As Single) As Single
        Iamb = ka * Ia
        Return Iamb
    End Function

    'function to calculate Idiffuse
    Function diffuse(ByVal kd As Single, ByVal IL As Single, ByVal L As Vector, ByVal N As Vector) As Single
        Dim value As Double = (DotProductof(L, N))
        If value < 0 Then
            value = 0
        End If
        Idif = kd * IL * value
        Return Idif
    End Function

    'function to calculate Itotal
    Function total(ByVal Iamb As Single, ByVal Idiff As Single) As Single
        Itot = Iamb + Idiff
        Return Itot
    End Function

    'function to calculate light vector
    Function lightvector(ByVal result As Vector, ByVal viewer As Vertex, ByVal center As Vertex) As Vector
        VS(8) = MultiplyMat1(center, view)
        VS(8) = MultiplyMat1(VS(8), screen)
        VS(9) = MultiplyMat1(viewer, view)
        VS(9) = MultiplyMat1(VS(9), screen)

        result.i = VS(9).x - VS(8).x
        result.j = VS(9).y - VS(8).y
        result.k = VS(9).z - VS(8).z

        Return result
    End Function

    'function to calculate the second light vecotr
    Function lightvectordua(ByVal result As Vector, ByVal lights As Vertex, ByVal center As Vertex) As Vector
        VS(8) = MultiplyMat1(center, view)
        VS(8) = MultiplyMat1(VS(8), screen)
        VS(10) = MultiplyMat1(lights, view)
        VS(10) = MultiplyMat1(VS(10), screen)

        result.i = VS(10).x - VS(8).x
        result.j = VS(10).y - VS(8).y
        result.k = VS(10).z - VS(8).z

        Return result
    End Function

    'function to calculate unit vector
    Function unitVector(ByVal V As Vector) As Vector
        Dim result As New Vector
        Dim divider As Single

        divider = Math.Sqrt(V.i ^ 2 + V.j ^ 2 + V.k ^ 2)

        If divider = 0 Then
            result.i = 0
            result.j = 0
            result.k = 0
        Else
            result.i = V.i / divider
            result.j = V.j / divider
            result.k = V.k / divider
        End If

        Return result
    End Function

    'set translate and rotation matrixes
    Sub SetTranslateRotateMatrix(ByRef dx As Single, ByRef dy As Single, ByRef dz As Single, ByRef tetax As Single, ByRef tetay As Single, ByRef tetaz As Single)
        SetColMat(Translate, 0, 1, 0, 0, dx)
        SetColMat(Translate, 1, 0, 1, 0, dy)
        SetColMat(Translate, 2, 0, 0, 1, dz)
        SetColMat(Translate, 3, 0, 0, 0, 1)

        SetColMat(Rotatez, 0, cos(tetaz), -sin(tetaz), 0, 0)
        SetColMat(Rotatez, 1, sin(tetaz), cos(tetaz), 0, 0)
        SetColMat(Rotatez, 2, 0, 0, 1, 0)
        SetColMat(Rotatez, 3, 0, 0, 0, 1)

        SetColMat(Rotatey, 0, cos(tetay), 0, sin(tetay), 0)
        SetColMat(Rotatey, 1, 0, 1, 0, 0)
        SetColMat(Rotatey, 2, -sin(tetay), 0, cos(tetay), 0)
        SetColMat(Rotatey, 3, 0, 0, 0, 1)

        SetColMat(Rotatex, 0, 1, 0, 0, 0)
        SetColMat(Rotatex, 1, 0, cos(tetax), -sin(tetax), 0)
        SetColMat(Rotatex, 2, 0, sin(tetax), cos(tetax), 0)
        SetColMat(Rotatex, 3, 0, 0, 0, 1)
    End Sub

    'set the vertices
    Sub SetPoints()
        For i As Integer = 0 To 8
            vertices(i) = New Vertex
        Next

        SetVertex(vertices(0), -1, -1, 1)
        SetVertex(vertices(1), 1, -1, 1)
        SetVertex(vertices(2), 1, 1, 1)
        SetVertex(vertices(3), -1, 1, 1)
        SetVertex(vertices(4), -1, -1, -1)
        SetVertex(vertices(5), 1, -1, -1)
        SetVertex(vertices(6), 1, 1, -1)
        SetVertex(vertices(7), -1, 1, -1)
        SetVertex(vertices(8), 0, 0, -1) 'center point of surface(0)

    End Sub

    'set the edges with vertex index
    Sub SetEdges()
        For i As Integer = 0 To 11
            edges(i) = New Edge
        Next

        SetEdge(edges(0), 0, 1)
        SetEdge(edges(1), 1, 2)
        SetEdge(edges(2), 2, 3)
        SetEdge(edges(3), 3, 0)
        SetEdge(edges(4), 4, 5)
        SetEdge(edges(5), 5, 6)
        SetEdge(edges(6), 6, 7)
        SetEdge(edges(7), 7, 4)
        SetEdge(edges(8), 0, 4)
        SetEdge(edges(9), 1, 5)
        SetEdge(edges(10), 2, 6)
        SetEdge(edges(11), 3, 7)

    End Sub

    'set the surfaces with vertex index
    Sub SetSurfaces()
        For i As Integer = 0 To 5
            surfaces(i) = New Surface
        Next

        SetSurface(surfaces(0), 0, 1, 2, 3)
        SetSurface(surfaces(1), 7, 6, 5, 4)
        SetSurface(surfaces(2), 1, 5, 6, 2)
        SetSurface(surfaces(3), 4, 0, 3, 7)
        SetSurface(surfaces(4), 4, 5, 1, 0)
        SetSurface(surfaces(5), 2, 6, 7, 3)

    End Sub

    'configure the parameters
    Private Sub configureBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles configureBtn.Click
        'light source
        If (xSource.Text <> "" And ySource.Text <> "" And zSource.Text <> "") Then
            viewer.x = xSource.Text
            viewer.y = ySource.Text
            viewer.z = zSource.Text
            viewer.w = 1

            SetVertex(vertices(9), viewer.x, viewer.y, viewer.z) 'viewer
            Console.WriteLine(viewer.x & " " & viewer.y & " " & viewer.z)

        Else
            MessageBox.Show("Please fill all the light source coordinates.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ambientBox.Text = ""
            diffuseBox.Text = ""
        End If

        'light source 2
        If (xSource2.Text <> "" And ySource2.Text <> "" And zSource2.Text <> "") Then
            checkL = 1
            lights.x = xSource2.Text
            lights.y = ySource2.Text
            lights.z = zSource2.Text
            lights.w = 1

            SetVertex(vertices(10), lights.x, lights.y, lights.z) 'light 2
            Console.WriteLine(lights.x & " " & lights.y & " " & lights.z)
        Else
            Dim quickmath As Integer
            quickmath = 2 + 2 - 1
            checkL = 0
        End If


        'ka & kd
        If (ambientBox.Text <> "" And diffuseBox.Text <> "") Then
            If (Single.TryParse(ambientBox.Text, check1) And check1 >= 0 And check1 <= 1 And Single.TryParse(diffuseBox.Text, check2) And check2 >= 0 And check2 <= 1) Then
                ka = ambientBox.Text
                kd = diffuseBox.Text
            Else
                MessageBox.Show("ka and kd cannot exceed 1 or less than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Please fill all the the coefficients.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ambientBox.Text = ""
            diffuseBox.Text = ""
        End If

    End Sub

    'Calculated culling and shading
    Sub BackFaceCulling(ByRef mesh1() As Surface, ByVal coor1() As Vertex, view As Vertex, center As Vertex, lights As Vertex, ka As Single, kd As Single)
        Dim N, V, L As New Vector
        Dim UN(5) As Vector
        Dim Ltwo As New Vector
        Dim i As Integer
        Dim amb, diff, diff2, tot As Double
        graph.Clear(PictureBox1.BackColor)

        L = lightvector(L, view, center)

        If (checkL = 1) Then
            Ltwo = lightvectordua(Ltwo, lights, center)
            SetVector(Ltwo, Ltwo.i, Ltwo.j, Ltwo.k)

            Console.WriteLine(Ltwo.i & " " & Ltwo.j & " " & Ltwo.k)
        End If

        SetVector(L, L.i, L.j, L.k)

        SetVector(V, 0, 0, -5)

        'Culling
        For i = 0 To mesh1.Length - 1
            N = Normalof(mesh1(i), coor1)
            If DotProductof(V, N) >= 0 Then
                mesh1(i).isVisible = False
                'clear screen
            Else
                mesh1(i).isVisible = True
                'display yg nampak

                UN(i) = unitVector(N)

                L = unitVector(L)

                amb = ambient(ka, Ia)
                diff = diffuse(kd, IL, L, UN(i)) * 5 'biar kliatan

                If (checkL = 1) Then
                    Ltwo = unitVector(Ltwo)
                    diff2 = diffuse(kd, IL, Ltwo, UN(i)) * 5 'biar kliatan
                    tot = total(amb, diff) + diff2
                Else
                    tot = total(amb, diff)
                End If

                Dim v1 As New Point(VS(surfaces(i).vertex1).x, VS(surfaces(i).vertex1).y)
                Dim v2 As New Point(VS(surfaces(i).vertex2).x, VS(surfaces(i).vertex2).y)
                Dim v3 As New Point(VS(surfaces(i).vertex3).x, VS(surfaces(i).vertex3).y)
                Dim v4 As New Point(VS(surfaces(i).vertex4).x, VS(surfaces(i).vertex4).y)

                Dim points As Point() = {v1, v2, v3, v4}
                    If tot < 1 Then
                        If redClr.Checked Then
                            myBrush = New SolidBrush(Color.FromArgb(255 * tot, tot, tot))
                            graph.FillPolygon(myBrush, points)
                            DrawCube(Color.Transparent)
                        ElseIf greenClr.Checked Then
                            myBrush = New SolidBrush(Color.FromArgb(tot, 255 * tot, tot))
                            graph.FillPolygon(myBrush, points)
                            DrawCube(Color.Transparent)
                        ElseIf blueClr.Checked Then
                            myBrush = New SolidBrush(Color.FromArgb(tot, tot, 255 * tot))
                            graph.FillPolygon(myBrush, points)
                            DrawCube(Color.Transparent)
                        ElseIf allClr.Checked Then
                            myBrush = New SolidBrush(Color.FromArgb(255 * tot, 255 * tot, 255 * tot))
                            graph.FillPolygon(myBrush, points)
                            DrawCube(Color.Transparent)
                        Else
                            MessageBox.Show("Please specify the colors.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        tot = 1
                        'MessageBox.Show("RGB Overflows", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                End If
        Next
        PictureBox1.Image = bmp
    End Sub

    'calculated normal of each surfaces
    Function Normalof(ByVal mesh As Surface, ByVal Point() As Vertex) As Vector
        Dim A, B As Vector
        Dim p1, p2, p3 As Integer

        p1 = mesh.vertex1
        p2 = mesh.vertex2
        p3 = mesh.vertex3
        A = New Vector
        B = New Vector

        A.i = Point(p1).x - Point(p2).x
        A.j = Point(p1).y - Point(p2).y
        A.k = Point(p1).z - Point(p2).z
        SetVector(A, A.i, A.j, A.k)
        B.i = Point(p3).x - Point(p2).x
        B.j = Point(p3).y - Point(p2).y
        B.k = Point(p3).z - Point(p2).z
        SetVector(B, B.i, B.j, B.k)
        Return CrossProductof(A, B)
    End Function


    'handles the drawing of the cube
    Sub Draw()
        graph.Clear(PictureBox1.BackColor)
        DrawCube(Color.Transparent)
        BackFaceCulling(surfaces, VS, vertices(9), vertices(8), vertices(10), ka, kd)
        PictureBox1.Refresh()
    End Sub

    'calculates cube
    Sub DrawCube(ByVal color As Color)
        Dim pen = New Pen(color)
        Dim a, b, c, d, e, f, g, h, j, k, l, m, n, o, p, q As Integer

        SetTranslateRotateMatrix(dx, dy, dz, tetax, tetay, tetaz)

        For i = 0 To 8
            pr = MultiplyMat2(Rotatez, Rotatey)
            pr = MultiplyMat2(pr, Rotatex)
            pr = MultiplyMat2(pr, Translate)
            VR(i) = MultiplyMat1(vertices(i), pr)
            VS(i) = MultiplyMat1(VR(i), view)
            VS(i) = MultiplyMat1(VS(i), screen)
        Next
        VS(9) = MultiplyMat1(vertices(9), screen)

        'this is for drawing the lines of the cube, you may use it or not
        'or just make Color.Transparent
        For i = 0 To surfaces.Length - 1
            If surfaces(i).isVisible Then
                a = VS(surfaces(i).vertex1).x
                b = VS(surfaces(i).vertex1).y
                c = VS(surfaces(i).vertex2).x
                d = VS(surfaces(i).vertex2).y
                graph.DrawLine(pen, a, b, c, d)
                e = VS(surfaces(i).vertex2).x
                f = VS(surfaces(i).vertex2).y
                g = VS(surfaces(i).vertex3).x
                h = VS(surfaces(i).vertex3).y
                graph.DrawLine(pen, e, f, g, h)
                j = VS(surfaces(i).vertex3).x
                k = VS(surfaces(i).vertex3).y
                l = VS(surfaces(i).vertex4).x
                m = VS(surfaces(i).vertex4).y
                graph.DrawLine(pen, j, k, l, m)
                n = VS(surfaces(i).vertex4).x
                o = VS(surfaces(i).vertex4).y
                p = VS(surfaces(i).vertex1).x
                q = VS(surfaces(i).vertex1).y
                graph.DrawLine(pen, n, o, p, q)

            End If
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        tetaz = 0
        tetay = 0
        tetax = 0
        dx = 0
        dy = 0
        dz = 0

        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        graph = Graphics.FromImage(bmp)
        PictureBox1.Image = bmp

        SetPoints()
        SetEdges()
        SetSurfaces()

        SetColMat(view, 0, 1, 0, 0, 0)
        SetColMat(view, 1, 0, 1, 0, 0)
        SetColMat(view, 2, 0, 0, 1, 0)
        SetColMat(view, 3, 0, 0, 0, 1)

        SetColMat(screen, 0, 50, 0, 0, (PictureBox1.Width / 2))
        SetColMat(screen, 1, 0, -50, 0, (PictureBox1.Height / 2))
        SetColMat(screen, 2, 0, 0, 1, 0)
        SetColMat(screen, 3, 0, 0, 0, 1)

    End Sub

    'draw cube
    Private Sub drawBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles drawBtn.Click
        tetaz = 0
        tetay = 0
        tetax = 0
        dx = 0
        dy = 0
        dz = 0
        If (xSource.Text <> "" And ySource.Text <> "" And zSource.Text <> "" And ambientBox.Text <> "" And diffuseBox.Text <> "") Then
            Draw()
        Else
            MessageBox.Show("Please fill all the parameters first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    'handles keypresses and increases/decreases dx/dy/dz/tetax/tetay/tetaz based on keypress
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        ' Sets Handled to true to prevent other controls from 
        ' receiving the key if an arrow key was pressed

        Select Case e.KeyCode
            Case Keys.D
                If TranslateRadio.Checked Then
                    dx = dx + 0.1
                    Draw()
                ElseIf RotateRadio.Checked Then
                    tetax = tetax + 1
                    Draw()
                Else
                    MessageBox.Show("No command is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                e.Handled = True
            Case Keys.A
                If TranslateRadio.Checked Then
                    dx = dx - 0.1
                    Draw()
                ElseIf RotateRadio.Checked Then
                    tetax = tetax - 1
                    Draw()
                Else
                    MessageBox.Show("No command is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                e.Handled = True
            Case Keys.W
                If TranslateRadio.Checked Then
                    dy = dy + 0.1
                    Draw()
                ElseIf RotateRadio.Checked Then
                    tetay = tetay + 1
                    Draw()
                Else
                    MessageBox.Show("No command is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                e.Handled = True
            Case Keys.S
                If TranslateRadio.Checked Then
                    dy = dy - 0.1
                    Draw()
                ElseIf RotateRadio.Checked Then
                    tetay = tetay - 1
                    Draw()
                Else
                    MessageBox.Show("No command is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                e.Handled = True
            Case Keys.E
                If TranslateRadio.Checked Then
                    dz = dz - 0.1
                    Draw()
                ElseIf RotateRadio.Checked Then
                    tetaz = tetaz - 1
                    Draw()
                Else
                    MessageBox.Show("No command is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                e.Handled = True
            Case Keys.Z
                If TranslateRadio.Checked Then
                    dz = dz + 0.1
                    Draw()
                ElseIf RotateRadio.Checked Then
                    tetaz = tetaz + 1
                    Draw()
                Else
                    MessageBox.Show("No command is selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                e.Handled = True
        End Select
    End Sub

End Class
