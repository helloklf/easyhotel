   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls  5       Project_Term2_BaseData.   (Project_Term2_BaseData.Pages.CountryInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;my,clr-namespace:MyControls;assembly=MyControls     5      -   5          � 	Resources  5       �� Source�� 5	   
   $ ../Style.xaml?�6   %    66   .��5      ]� .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v      MyControls.DataListMenu  5   
   -   5          Name$ IsCheck��5   /   $	��Top=�6   6�   �� 5   
   $��2��6   $	��Top=�6    J� Opacity$	 0.6Q�61   $
��2,10q�6?   ��6M   �� *
Background+ �� ElementName$ C��6   ]� 5   
   $��Right=�6   .+�5      �� -   5        $��o��5      $��20��6    $��Center=�6.   $	 0.7Q�6P   $��0,0,1,0q�6^   ��6x   �� *
Foreground+$ C��6�   �� 5      $��Disabled=�6   $��Hidden=�6D   .��5      �� -   5        $	��Tab��5   _   $��0q�64   $y�	Collapsed=�6H   $��5q�6�   ��6   Z� ��6j   Z� .@�5      �� $y�	Collapsed=�6   $��0q�6b   ��65   Z� ��6K   Z� .��5      �� .+�5      �� $��新增国家��6(   $��25(�64   $��	0,5,10,10q�6B   ��6U   �� *
Foreground+$ C��6�   ]� 5      $��2q�6(   .+�5   "   �� $��国家名称*：��6,      	LeftTitle#��[  6:   6_   �� 5   "   -   5        $��InText��5   *    � ToolTip$? 9最长15个字符的证件名，如:二代居民身份证��68     ShortTextBox#��[ 6X   5         MyControls.OK  5      -   5        $��Right=�5   @   $
��10,5q�6\   6l   5      5      �� 5!      $y�	Collapsed=�6   $��0q�6L   ��65   Z� .��5"      �� .+�5#      �� $	��Top=�6(   $��修改国家��6=   $��25(�6I   $��	0,5,10,10q�6W   ��6j   �� *
Foreground+$ C��6�   ]� 5$      $��2q�6(   .+�5%   "   �� $��国家名称*：��6,   #��[  6:   6_   �� 5&   "   -   5        $��UpText��5&   *   $? 9最长15个字符的国家名，如:中华人民共和国��68   #��[ 6X   5'      �� 5(       �� Orientation$ 
Horizontal=�6)   $��Right=�6B   $��5q�6^   .+�5)   "      MyControls.No  -	   5        5)   A     5*   "   -
   5        $��Right=�5*   F   $
��10,5q�6b   6r   5+      5,      5-      5.      5/      50      ]� 51   
   $��5q�6   $	��Top=�6   .+�52         MyControls.DataListBox  -   5          Name$ LB��52      	   SelectedValuePath$	 ALevelID��6)   
   ItemTemplate
 53      �� 54      .R�55      ]� ���#FFFFCC$	��250��69   .+�56      �� $��10q�6)   .+�57   "   �� $ 
Horizontal=�6-   $y�Visible=�6F   .+�58   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�59   *   �� $��Center=�64   	编号：6T   �� 5:   *   $��Center=�64    �� Padding$ 2q�6j   ��6O   �� *	CountryID+6x   5;   '   �� 5<   &   $��20,0,0,0q�61   $ 
Horizontal=�6C   $��Center=�6\   .+�5=   *   �� $��Center=�64   有效性：6U   �� 5>   *   $��Center=�64   $ 2q�6l   ��6O   �� *IsValidText+6z   5?   '   5@   #   �� 5A   "   $ 
Horizontal=�6-   .+�5B   &   �� $��Center=�60   国家名称：6R   �� 5C   &   $��Center=�60   $��18(�6K   $ 2q�6v   ��6Y   �� *CountryName+6�   5D   #   5E      5F      5G      5I      5J      5K      5L      