import 'package:flutter/material.dart';
import 'package:hgv_hours/main.dart';
import 'package:provider/provider.dart';

class NewShift extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var appState = context.watch<MyAppState>();

    var shiftsController = appState.shiftsController;

    return Row(
      children: [
        Text('Aids'),
      ],
    );
  }
}
