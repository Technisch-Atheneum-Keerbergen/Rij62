# [PROJECT](https://github.com/orgs/Technisch-Atheneum-Keerbergen/projects/1)

# Install

## Install the following vscode extensions
- C#
- .NET Install Tool (should be auto installed by the C# extension).
- C# Dev Kit.

## Install dotnet 10
- Open the command palet in vscode and select Show and run commands (Control+Shift+p).
- Install dotnet 10 via Install tool.
- Open a terminal and run `dotnet tool install --global dotnet-ef` to install the entity framework tools

## Setup the database
- Install docker desktop and run the command docker `compose up -d` to start the database.
- Alternatively you can Install postgres directly without docker
- With postgress running run `dotnet ef database update` to apply the migrations to the db

## Run the code
- Go to the run and debug menu on the left and select run and debug.


# Utilities

## Reset the database
If you get an exception while running a database command. It is likely that your database is in a wrong state

Try running `dotnet ef database update` If this doesn't fix it try fully clearing the database
```
docker compose exec -i db /bin/psql

DROP SCHEMA public CASCADE;
CREATE SCHEMA public;
dotnet ef database update
```

<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a id="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![project_license][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/Technisch-Atheneum-Keerbergen/Rij62">
    <img src="https://userpicture20.smartschool.be/User/Userimage/hashimage/hash/1045_9107718c-8b49-44a4-82c5-cf1baff923a1/plain/1/res/256" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Rij 62</h3>

  <p align="center">
    An app for a coffee bar to control orders and menu's.
    <br />
    <a href="https://github.com/Technisch-Atheneum-Keerbergen/Rij62"><strong>Explore the docs »</strong></a>
    <br />
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



### Built With

* [![Svelte][Svelte.dev]][Svelte-url]
* [![C#][Csharp.dev]][Csharp-url]
* [![PostgreSQL][Postgres.dev]][Postgres-url]

<!-- LICENSE -->
## License

Distributed under the project_license. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Your Name - [@twitter_handle](https://twitter.com/twitter_handle) - xavier.demaerel@takeerbergen.be

Project Link: [https://github.com/Technisch-Atheneum-Keerbergen/Rij62](https://github.com/Technisch-Atheneum-Keerbergen/Rij62)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* []()
* []()
* []()

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/Technisch-Atheneum-Keerbergen/Rij62.svg?style=for-the-badge
[contributors-url]: https://github.com/Technisch-Atheneum-Keerbergen/Rij62/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Technisch-Atheneum-Keerbergen/Rij62.svg?style=for-the-badge
[forks-url]: https://github.com/Technisch-Atheneum-Keerbergen/Rij62/network/members
[stars-shield]: https://img.shields.io/github/stars/Technisch-Atheneum-Keerbergen/Rij62.svg?style=for-the-badge
[stars-url]: https://github.com/Technisch-Atheneum-Keerbergen/Rij62/stargazers
[issues-shield]: https://img.shields.io/github/issues/Technisch-Atheneum-Keerbergen/Rij62.svg?style=for-the-badge
[issues-url]: https://github.com/Technisch-Atheneum-Keerbergen/Rij62/issues
[license-shield]: https://img.shields.io/github/license/Technisch-Atheneum-Keerbergen/Rij62.svg?style=for-the-badge
[license-url]: https://github.com/Technisch-Atheneum-Keerbergen/Rij62/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: images/screenshot.png

<!-- Shields.io badges. You can a comprehensive list with many more badges at: https://github.com/inttter/md-badges -->
[Svelte.dev]: https://img.shields.io/badge/Svelte-FF3E00?style=for-the-badge&logo=svelte&logoColor=white
[Svelte-url]: https://svelte.dev/

[Csharp.dev]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white
[Csharp-url]: https://learn.microsoft.com/en-us/dotnet/csharp/

[Postgres.dev]: https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white
[Postgres-url]: https://www.postgresql.org/
