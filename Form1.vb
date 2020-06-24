
' Author : Kenny Shah
' Date   : May 28, 2020
' Description : 
'   A simple VB.net form which allows a user to enter the 
'   number of units shipped by them in 7 days and in turn will 
'   help them to know how many average units have been shipped by them.

Option Strict On
Public Class Form1

    '---Variable Declarations---

    Dim Input As Integer        'Used for stroring user input.

    Dim Sum As Integer = 0      'Initializing sum to 0 for addition of the units user will enter.

    Dim Counter As Integer = 0  'Counter variable used for showing day as well as in average calculation.

    Dim Day As Integer = 1      'For storing the number of days.

    Dim Average As Double       'For storing the calculated average.

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '------MAIN PROGRAM LOGIC------

        'Cheking if the input field is empty if it is then prompting the user that field should not be empty.

        If String.IsNullOrEmpty(Units_Input.Text) Then
            MessageBox.Show("The Units Field Should Not Be Empty.", "Alert!")
            Units_Input.Focus()

            'Checking if the user enetered value is integer or not.

        ElseIf Integer.TryParse(Units_Input.Text, Input) = False Then

            MessageBox.Show("Units Value Should Be An Integer.", "Alert!")
            Units_Input.Focus()
            Units_Input.SelectAll()

            'To check wheter the user entered value is in the range 0-5000.

        ElseIf Input < 0 Or Input > 5000 Then

            MessageBox.Show("Units should be in range of 0-5000.", "Alert!")
            Units_Input.Focus()
            Units_Input.SelectAll()

            'If the input is properly validated then perfroming further calculations.

        Else

            TextBox2.Text &= CStr(Input) & vbCrLf  'This line will append the entered values in the texbox below which will act as an displaybox.
            Units_Input.Clear()                    'This line will clear the input field once the value is inserted in the program as well as in the displaybox.
            Sum += Input                      'It will sum the inputs the user has entered.
            Counter += 1            'This counter is used here to let the program know that after 7 values it has to stop the input and then show the output.
            Day += 1                    'This line is used to increment the day which gives us the numbers of day i.e. Day 1, Day 2, Day 3.... etc.

            If Counter = 7 Then
                Day = 7            'This block of code will prevent the counter from exceeding the number of days, i.e. at Day 7 it will stop and won't get any further.
            End If

            Label3.Text = CStr(Day)  'This label is used to display the Day number and by using the Cstr function the integer will be converted to string.
            Units_Input.Focus()
        End If



        Average = Sum / 7       'Used to calculate the average after getting the sum

        If Counter = 7 Then             'This codeblock will be executed when the counter reaches 7 and as a result it will lock the user input as well as the enter button.
            Units_Input.Enabled = False
            Button1.Enabled = False
            Output_Label.Text = CStr(" Average per day : " & Math.Round(Average, 2)) 'Calculated average shown in the label with 2 decimal places.
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Output_Label.Text = ""
        TextBox2.Clear()           'Once the reset button is clicked it will clear the output label, displaybox and will activate the inputbox and enter button.
        Label3.Text = CStr(1)
        Units_Input.Enabled = True
        Button1.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()                                                                      'By clicking the exit button the application stops working
    End Sub


End Class
