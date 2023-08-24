import 'package:carbon_icons/carbon_icons.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

const bottomContainerHeight = 80.0;
const activeCardColor = Color(0xff1d1e33);
const bottomContainerColor = Color(0xffeb1555);

class InputPage extends StatefulWidget {
  @override
  _InputPageState createState() => _InputPageState();
}

class _InputPageState extends State<InputPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('BMI CALCULATOR'),
        ), //AppBar
        body: Column(
          children: <Widget>[
            Expanded(
                child: Row(
              children: <Widget>[
                Expanded(
                  child: ReusableCard(
                    colour: Color(0xff333333),
                    cardChild: Column(
                      children: <Widget>[
                        Icon(
                          CarbonIcons.gender_male,
                          size: 80.0,
                        ),
                        Icon(
                          FontAwesomeIcons.mars,
                          size: 80.0,
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Text(
                          'MALE',
                          style: TextStyle(
                            fontSize: 18.0,
                            color: Color(0xFF8D8E98),
                          ),
                        )
                      ],
                    ),
                  ),
                ),
                Expanded(
                  child: ReusableCard(
                    colour: activeCardColor,
                    cardChild: Column(children: <Widget>[
                      Icon(
                        CarbonIcons.gender_male,
                        size: 80.0,
                      ),
                      Icon(
                        FontAwesomeIcons.mars,
                        size: 80.0,
                      ),
                    ]),
                  ),
                )
              ], //<Widget>[]
            )), // Row, Expanded
            Expanded(
              child: ReusableCard(colour: activeCardColor, cardChild: Column()),
            ),
            Expanded(
                child: Row(
              children: <Widget>[
                Expanded(
                  child: ReusableCard(
                      colour: activeCardColor, cardChild: Column()),
                ),
                Expanded(
                  child: ReusableCard(
                      colour: activeCardColor, cardChild: Column()),
                ),
              ], // <Widget>[]
            )), // Row, Expanded
            Container(
                color: bottomContainerColor,
                margin: EdgeInsets.only(top: 10.0),
                width: double.infinity,
                height: bottomContainerHeight,
                child: Column(
                  children: <Widget>[
                    Icon(FontAwesomeIcons.mars),
                    Text(
                      'MALE',
                      style: TextStyle(fontSize: 18.0),
                    ),
                  ],
                ))
          ], // <Widget>[]
        ) // Column
        ); // Scaffold
  }
}

class ReusableCard extends StatelessWidget {
  //const ReusableCard({     super.key,  });

  ReusableCard({required this.colour, required this.cardChild});

  final Color colour;
  final Widget cardChild;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.all(15.0),
      decoration: BoxDecoration(
        color: colour,
        borderRadius: BorderRadius.circular(10.0),
      ),
    );
  }
}

// Container(
// margin: EdgeInsets.all(15.0),
// decoration: BoxDecoration(
// colour: Color(0xff1d1e33),
// borderRadius: BorderRadius.circular(10.0),
// ),),
