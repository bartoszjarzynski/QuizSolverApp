   M S B A M L   `   `   `  ����C  ?QuizMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:QuizMVVMQuizMVVM  5   	       QuizMVVM.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:QuizMVVM     5   	     � Title$  QuizSolverApp��5   	   $	��450��5	   	   $	��800��5
   	   ���#222022 � 	Resources 5       �� 
TargetType   stylNastepnePytanie �� Property �� Value �� 	Resources  stylZakoncz  RoundButton��%�  &	        &	 �     &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       � ��
 � � �6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 25��65   5      5      5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       � ��
 �  ��6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 25��65   5      5      5      �� 5!   
   " ��6    5"      ���� 5#      '��       " ��6   .�5$      ��  �@��CornerRadius$ 30��65   5%      5&      .�5'      ��  � ��$ 10q�6'   �� 5(       � ��$ Arial Black)�6+   5)      5*      .��5,      �  � ColumnDefinitions 5-   
   �� 5.      �� 5/      �� 50      �� 51      �� 52       � RowDefinitions 54   
   �� 55      �� 56      �� 57      �� 58      �� 59      �� 5:      .+�5=   
   �� $I��CC:\Users\bartj\Desktop\Studia\SEM IV\PROGRAMOWANIE OiG\logoquiz.png��6   $��2��5>      �� 5@   
   $��1��6   $��0��5A      $��3��5B      $��2��5C      $��Arial Black)�5D      $��20(�5E      
������� �� TextAlignment$ Center=�5H      $��Center=�5I      ��5G      �� *
Question+	 �� Mode$	 OneWay=�5I      �� 5K   
   $��4��6   $��0��5L      $��Arial Black)�5M      $��30(�5N      
�������$ Center=�5Q      $��Center=�5R      ��5P      �� *	TimerText+$	 OneWay=�5R      �� 5T   
   $��0��6   $��2��5U      $��2��5V      $��2��5W      $��30(�5X      #���  5Y      $��A��5[   9   ��5Z      �� *	AnswerA+��5[      �� *AnswerButtonCommand+69   �� 5\   
   $��2��6   $��2��5]      $��2��5^      $��2��5_      $��30(�5`      #���  5a      $��B��5c   9   ��5b      �� *	AnswerB+��5c      �� *AnswerButtonCommand+69   �� 5d   
   $��0��6   $��4��5e      $��2��5f      $��2��5g      $��30(�5h      $��Arial Black)�5i      #���  5j      $��C��5l   9   ��5k      �� *	AnswerC+��5l      �� *AnswerButtonCommand+69   �� 5m   
   $��2��6   $��4��5n      $��2��5o      $��2��5p      $��30(�5q      #���  5r      $��D��5t   9   ��5s      �� *	AnswerD+��5t      �� *AnswerButtonCommand+69   �� 5v   
   $��4��6   $��1��5w      $��Arial Black)�5y      $��30(�5z      
�������$ Center=�5|      $��Center=�5}      ��5x      �� *Score+5}      �� 5   
   #��[  6   $��4��5�      $��2��5�      $��2��5�      $��Arial Black)�5�      $��35(�5�      $
��Next��5�      $��10,30,10,30q�5�      ��5�      �� *NextQuestionCommand+�� 5�   
   #��[ 6   $��4��5�      $��4��5�      $��2��5�      $��35(�5�      $��Arial Black)�5�      $	��End��5�      $��10,30,10,30q�5�      ��5�      �� *
EndCommand+5�      5�      