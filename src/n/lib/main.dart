import 'package:flutter/material.dart';
import 'input_page.dart';
import 'package:carbon_icons/carbon_icons.dart';

void main() => runApp(BMICalculator());

class BMICalculator extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData.dark().copyWith(
          scaffoldBackgroundColor: Colors.black,
          textTheme: TextTheme(bodyMedium: TextStyle(color: Colors.white)),
          primaryColor: Colors.white,
          appBarTheme: AppBarTheme(color: Colors.white24),
          secondaryHeaderColor: Colors.white),
      home: InputPage(),
    );
  }
}
