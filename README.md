# How-to-add-custom-axis-label-in-WinUI-SfCartesianChart.
This sample demonstrates how to add custom axis label in WinUI SfCartesianChart.

The appearance of the axis labels can be customized by using the LabelTemplate property of axis.

XAML
```
<chart:SfCartesianChart>
. . .
<chart:SfCartesianChart.Resources>
    <DataTemplate x:Key="labelTemplate">
        <Border BorderBrush="Blue"
				CornerRadius="5"
				BorderThickness="1">
            <TextBlock Text="{Binding Content}"
					   FontSize="12"
					   FontStyle="Italic"
					   FontWeight="Bold" 
					   Margin="3"/>
        </Border>
    </DataTemplate>
</chart:SfCartesianChart.Resources>
. . .
<chart:SfCartesianChart.XAxes>
    <chart:CategoryAxis LabelTemplate="{StaticResource labelTemplate}"/>
</chart:SfCartesianChart.XAxes>

</chart:SfCartesianChart>
```
![image](https://github.com/SyncfusionExamples/How-to-add-custom-axis-label-in-WinUI-SfCartesianChart/assets/113962276/32127637-bb2e-4618-bf60-e62b91eaf8c5)

## Smart Axis Labels
When there are more number of axis labels, they may overlap with each other. Chart axis provides support to handle the overlapping axis labels using the LabelsIntersectAction property. By default the LabelsIntersectAction value is Hide.

| Action      | Description |
|-------------|-----------------|
| None        | Used to display all the label even if it intersects  |
| Hide        | Used to hide the labels if it intersects             |
| MultipleRows| Used to move the labels to next row if it intersects |
| Auto        | Used to rotate the labels if it intersects           |

### Hide

![image](https://github.com/SyncfusionExamples/How-to-add-custom-axis-label-in-WinUI-SfCartesianChart/assets/113962276/e6c5461f-194a-421a-bda0-dbeb477f2eb7)

### MultipleRows

![image](https://github.com/SyncfusionExamples/How-to-add-custom-axis-label-in-WinUI-SfCartesianChart/assets/113962276/4b587eca-b41c-490a-b359-131d25d71e18)

### Auto

![image](https://github.com/SyncfusionExamples/How-to-add-custom-axis-label-in-WinUI-SfCartesianChart/assets/113962276/a2f06241-9acb-46d4-bf45-a970d06f014d)
