   M S B A M L   `   `   `  ����  NME2_Server_ManagerA    ;NME2_Server_Manager.LoginWindow.Window.Implementation.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NME2 Manager - Login��5   	   $	��279��6&   $	��349��63    � 
ResizeMode$ NoResize=�6?   ���	#FF3E3E3E � 	Resources 5         Key �� MergedDictionaries �� Source�� 5   
   
Styles   5      �� 5	      $4 ./NME2_Server_Manager;component/Nme2Styles.xaml?�6&   6`   �� 5
      $= 7/NME2_Server_Manager;component/Nme2Styles_Combobox.xaml?�6&   6i   �� 5      $; 5/NME2_Server_Manager;component/Nme2Styles_Button.xaml?�6&   6g   %    5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��	Username:��6   $��0��6$   $��0��64   $��14(�6A   $
��Bold"�6O   $��Right=�6a   $��5q�6}   ���	#FFDEDEDE6�   �� 5   
   -   5        $��txtUser��5   [     roundTextBox#���  6   $��Center=�69   $��0��6j   $	��200��6x   $��Center=�6�   $��1��6�   $��0��6�   $��14(�6�   $��5q�6�   $
��Bold"�6�   �� 5   
   $��	Password:��6   $��0��6$   $��1��64   $��14(�6A   $
��Bold"�6O   $��Right=�6a   $��5q�6}   ���	#FFDEDEDE6�   G� 5    
   -   5        $��txtPwd��5    c     roundPasswordBox#���  6   $��Center=�6A   $��1��6q   $��1��6~   $��1��6�   $	��200��6�   $��Center=�6�   $��14(�6�   $��5q�6�   $
��Bold"�6�   �� 5"   
   $��2��6   $��1��6"   $��Center=�62   $��0,5,0,5q�6O   .+�5#      �� -   5        $��btnLogin��5#   [   $��2��6   $��Login��6"   $��33��62   $��Center=�6>   $	��Top=�6k   $	��200��6�   $��14(�6�   $��Normal$�6�   $
��Bold"�6�    �� 	IsDefault . 
���   ����	#FFFFD6246  �� 5$      .��5%      �� $
��Wrap=�6    �� TextAlignment$ Center=�60   $-��'Full write access to edit the missions.��6G   ���	#FFD8D8D86�   5&      5'      �� 5*   
   $��3��6   $��1��6"   $��Center=�62   $��0,5,0,5q�6O   .+�5+      �� -   5        $��btnGuest��5+   [   $��3��6   $��Guest��6"   $��23��62   $��Center=�6>   $	��Top=�6k   $	��200��6�   ���	#FF64C754$
��Bold"�6�   �� 5,      .��5-      �� $
��Wrap=�6   $ Center=�60   $8��2Allows browsing the missions without write access.��6G   ���	#FFD8D8D86�   5.      50      51      52      