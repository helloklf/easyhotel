   M S B A M L   `   `   `  ���� Q  MProject_Term2_BaseData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  /    )Project_Term2_BaseData.Pages.AccreditType   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'myclr-namespace:MyControls     -   $��20q�  � 	Resources   �� Source�� $ ../Style.xaml?�%    .��]� $	��450��$��Center=�$��Center=�.+��� $��5q�$	��Top=�._��� -   $	��Tab��$��0q���Z� ��Z� .@��� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $��新增类型��$��18(�$��	0,10,10,0q����� *
Foreground+ �� ElementName$ C���� $��2��$	��Top=�$��0q�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��授权类型：��   	LeftTitle#��[  �� -    ��Name$ InText�� � ToolTip$/ )授权等级(15字以内)，如:管理员��  ShortTextBox#��[ ]� $��2q�.+��� $��授权说明*：��#��[  �� -   $ InRemark��$  备注信息(100字以内)��  LongTextBox#��[    MyControls.yes     MyControls.yes   	MouseDown$ Label_MouseDown���� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $��修改类型��$��18(�$��	0,10,10,0q����� *
Foreground+$ C���� $��2��$	��Top=�$��0q�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��授权类型：��#��[  �� -   $ UpText��$/ )授权等级(15字以内)，如:管理员��#��[ ]� $��2q�.+��� $��授权说明*：��#��[  �� -   $ UpRemark��$  备注信息(100字以内)��#��[ ��  �� Orientation$ 
Horizontal=�$��Right=�$��5q�.+�   MyControls.Back     MyControls.Back   	MouseDown$ 
ReturnList��  $ Label_MouseDown_1��]� $	��Top=����#2000$��5q�.+��� $��Right=�.+��� -   $ C��$y�	Collapsed=����� *	ForeColor+���� *	BgColor+�� -    ��Name$ IsCheck��$��5q����� *
Foreground+$ C��   MyControls.B     MyControls.B	   	MouseDown$	 SelectedItemEnabled��   MyControls.A     MyControls.A
   	MouseDown$
 SelectedItemEnabledNo���� -	    ��Name$ LB��
������� �� SelectedValuePath$ ALevelID��
����������� .R��� .+��� $ 
Horizontal=�$y�Visible=�.+��� $ 
Horizontal=�$��Center=�.+��� $��Center=�	编号：�� $��Center=� �� Padding$ 2q����� *
ALevelID+�� $��20,0,0,0q�$ 
Horizontal=�$��Center=�.+��� $��Center=�有效性：�� $��Center=�$ 2q����� *	IsValid+�� $��20,0,0,0q�$ 
Horizontal=�.+��� $��Center=�等级称号：�� $��Center=�$ 2q����� *
ALevelName+�� $ 
Horizontal=�.+��� $��Center=�说明备注：�� $��Center=�$
��Wrap=�$ 2q����� *ALevelRemark+