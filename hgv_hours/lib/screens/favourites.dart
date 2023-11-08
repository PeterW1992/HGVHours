import 'package:flutter/material.dart';
import 'package:hgv_hours/main.dart';
import 'package:provider/provider.dart';

class FavouritesPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var appState = context.watch<MyAppState>();

    var favourites = appState.favorites;

    if (appState.favorites.isEmpty) {
      return Center(
        child: Text('No favorites yet.'),
      );
    }

    return ListView(
      children: [
        Padding(
          padding: const EdgeInsets.all(20),
          child: Text('You have '
              '${appState.favorites.length} favorites:'),
        ),
        for (var favourite in favourites)
          ListTile(
            title: Text(favourite.asLowerCase),
            leading: Icon(Icons.favorite),
          )
      ],
    );
  }
}
