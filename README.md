<a name="readme-top"></a>

<br />
<div align="center">
  <a href="https://github.com/Vasenka88/Cities-Ukrainian-Localization/">
    <img src="https://steamuserimages-a.akamaihd.net/ugc/2021604543003289244/ED4DD6A0E15BDADE98E65D2D8573D7EBB64C8362/?imw=128&imh=128&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true" alt="Logo" width="80" height="80">
  </a>

<details>
  <summary>Зміст/Table of content</summary>
  <ol>
    <li>
      <a href="#про-проект">Про проект</a>
    </li>
    <li>
      <a href="#встановлення">Встановлення</a>
      <ul>
        <li><a href="#через-steam-workshop">Steam Workshop</a></li>
        <li><a href="#вручну">Ручне</a></li>
      </ul>
    </li>
    <li><a href="#помилки-та-неперекладене">Помилки та неперекладене</a></li>
    <li><a href="#підтримка">Підтримка</a></li>
    <li><a href="#info-for-community">Info for Community</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## Про проект

Українізатор, українська локалізація, український переклад, назв багато — суть одна: грати в ігри рідною мовою, та показати видавцям, що наша мова — має значення.<br>
Це класичний мод-переклад для Cities: Skylines. Таких модів дуже багато в Воркшопі, і вони не дуже між собою різняться. Тож цей мод створений на основі <a href="https://github.com/Nasz/Cities-Skylines-Mod_Lang_TH">Тайської локалізації</a>. Але "переклад" .locale у .po і назад виконаний за допомогою <a href="https://github.com/hanskurppa/csfi">Фінської локалізації</a> (так фінська компанія не має рідної мови у своїй грі — парадокс). Компіляція виконана на Лінукс за допомогою Makefile, бо мені так простіше.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Встановлення

Тут є два варіанти: через модифікацію та вручну. Вручну для тих, хто не хоче обтяжувати себе зайвими модами.

### Через модифікацію
<ol>
    <li>
      <ul>
        Для Steam-версій:<br>
        Підписуємось на <a href="https://steamcommunity.com/sharedfiles/filedetails/?id=3012910170">мод</a>
        <img src="https://i.imgur.com/A5cArmq.png" alt="workshop_subscribe" width=900></img>
      </ul>
      <ul>
        Для всіх інших:<br>
        Завантажуємо <i>Mod_Lang_UA.dll</i> з GitHub, далі створюємо теку <i>Українізатор</i> за цим шляхом:<br> 
        Windows: <i>%LOCALAPPDATA%\Colossal Order\Cities_Skylines\Addons\Mods</i><br>
        MacOS: <i>~/Library/Application Support/Colossal Order/Cities_Skylines/Addons/Mods</i><br>
        Linux: <i>~/.local/share/Colossal Order/Cities_Skylines/Addons/Mods</i>
      </ul>
    </li>
    <li>
      Заходимо в <b>Content Manager</b> у грі, далі в <b>Mods</b> та вмикаємо
      <img src="https://i.imgur.com/lqM5fa0.png" alt="content_manager_on" width=900></img>
    </li>
    <li>
      Якщо у вас не вибралося автоматично, то далі заходимо в <b>Settings</b>, <b>Gameplay</b> та обираємо мову
      <img src="https://i.imgur.com/cbdEqJm.png" alt="settings_select" width=900></img>
    </li>
    <li>
      Насолоджуємось грою
      <img src="https://steamuserimages-a.akamaihd.net/ugc/2013723347166249717/F797E790997590A9860CF74E420D34877E5727EE/?imw=637&imh=358&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true" alt="final" width=900></img><br>
      Щоб оновити мод для не steam-версій, просто замінюємо мод в теці.
    </li>
</ol>

### Вручну

<ol>
    <li>
      Завантажте файл локалізації за цим посиланням:<br>
      https://drive.google.com/drive/folders/1q8SZfQE3ZkZAMC3Kni3DU2ihpijPdtfQ?usp=drive_link (можна і з GitHub, але на диску швидше оновлюється)
    </li>
    <li>
      Перейдіть до локальних файлів гри, по цьому шляху: <br>
      Steam: <i>C:\Program Files (x86)\Steam\steamapps\common\Cities_Skylines\Files\Locale</i><br>
      Epic: <i>C:\Program Files\Epic Games\CitiesSkylines\Files\Locale</i><br>
      Та киньте туди завантажений файл
    </li>
    <li>
      Далі заходимо в <b>Settings</b>, <b>Gameplay</b> та обираємо мову
      <img src="https://i.imgur.com/cbdEqJm.png" alt="settings_select" width=900></img>
    </li>
    <li>
      Насолоджуємось грою
      <img src="https://steamuserimages-a.akamaihd.net/ugc/2013723347166249717/F797E790997590A9860CF74E420D34877E5727EE/?imw=637&imh=358&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true" alt="final" width=900></img><br>
      Щоб оновити переклад, просто замінюємо його в теці.
    </li>
</ol>

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Помилки та неперекладене

Перекладена не вся гра, такі DLC як Hotels & Retreats, Brooklyn & Queens, Railroads of Japan, Shopping Malls, Sports Venues, Campus та Africa in Miniature були перекладені частково, або переклад відсутній зовсім. Також не перекладено багато повідомлень Чірпера, сповіщень про новий контент (з'являється при заході в гру, якщо воно сховане, то показується після завантаження нових DLC чи оновлень гри). Прошу не надсилати подібне до гугл форми яка вказана нижче.

Що надсилати до гугл форми? Помилки, неперекладені частини гри які не були вказані вище

Сама гугл форма:
https://forms.gle/RYFjFLC2M71cSEt4A

При використанні модів Custom Data та Vehicle Skins виникають помилки при запуску гри, що ніяк не перешкоджають роботі жодного з модів. Це пов'язано з тим, що ці моди не розпізнають українську.
Також не рекомендовано залишати автовибір мови в налаштуваннях модів.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Автори
Автор перекладу: <a href="https://steamcommunity.com/id/kemza08">Kemza</a><br>
Автор моду: <a href="https://steamcommunity.com/id/vasenka88">Vasenka88</a>

## Підтримка

А підтримати цей переклад ви можете донатом на вказані тут благодійні фонди(але можете донатити і в інші)

Фонд Сергія Притули:<br>
https://prytulafoundation.org/<br>
Повернись живим:<br>
https://savelife.in.ua/donate/#donate-army-card-once<br>
Госпітальєри:<br>
https://www.hospitallers.life/needs-hospitallers<br>
UAnimals:<br>
https://uanimals.org/how-to-help/?regular&utm_source=search&utm_medium=cpc&utm_campaign=search_uanimals_ukraine&utm_term={uanimals}&gclid=CjwKCAjw8ZKmBhArEiwAspcJ7rYyrYvO5Ra1Xa7j9svDg46QFi4bcjQKAwV79Rt37y6l2Z_p8FyngRoCHZEQAvD_BwE<br>
UAID:<br>
https://www.u-aid.org/<br>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Info for Community

This is a classic mod translation for Cities: Skylines. There are a lot of such mods in the Workshop, and they are not very different from each other. So this mod is created based on <a href="https://github.com/Nasz/Cities-Skylines-Mod_Lang_TH">Thai localization</a>. But the "translation" of .locale to .po and back is done using the <a href="https://github.com/hanskurppa/csfi">Finnish localization</a> (yes, the Finnish company does not have a native language in its own game — paradox interactive). The compilation is done on Linux using Makefile, because it's easier for me.

<p align="right">(<a href="#readme-top">back to top</a>)</p>
