using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL bağlantısı için
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using otobusotomasyonu;
using System.Media;
using System.IO;

namespace otobusotomasyonu
{
    public partial class Form2 : Form
    {
        // Servis çalışanları sözlüğü
        private Dictionary<string, List<string>> servisCalisanlari = new Dictionary<string, List<string>>()
{
    { "Menemen", new List<string>{
        "Ahmet Yılmaz", "Ayşe Kaya", "Fatma Demir", "Mehmet Arslan",
        "Emre Şahin", "Elif Çelik", "Hakan Aksoy", "Selin Yıldız", "Deniz Kılıç", "Ece Özkan",
        "Serkan Doğan", "Zehra Akbulut", "Murat Şen", "Merve Yılmaz", "Ali Çetin", "Gamze Kurt",
        "Barış Yıldırım", "Seda Aydın", "Mustafa Polat", "Derya Acar", "Okan Demirtaş", "Funda Kaplan",
        "Volkan Kaan", "Sibel Şimşek", "Tolga Korkmaz", "Nazlı Öztürk", "Burak Erdem", "Selma Kılıç",
        "Cihan Demir", "Büşra Güngör", "Onur Ateş", "Zeynep Yalçın", "Kemal Kara", "Sevgi Özdemir",
        "Yusuf Akın", "Nilay Tuncer", "Fatih Yıldırım", "Gülşah Koç", "Erdem Arslan", "Melis Kaya"
    }},
    { "Aliağa", new List<string>{
        "Cem Yılmaz", "Zeynep Demir", "Mert Arslan", "İpek Kaya",
        "Ömer Acar", "Dilan Korkmaz", "Engin Güneş", "Ceyda Aydın", "Oğuzhan Öztürk", "Gizem Kaplan",
        "Hüseyin Aktaş", "Pelin Doğan", "Fırat Yalçın", "Sevda Şahin", "Eren Çetin", "Burcu Kılıç",
        "Serhat Özdemir", "Şebnem Yılmaz", "Baran Tekin", "Gamze Korkmaz", "İsmail Koç", "Cansu Demirtaş",
        "Volkan Şen", "Selin Acar", "Murat Yıldırım", "Aslı Tuncer", "Emre Kaplan", "Merve Aydın",
        "Halil Can", "Derya Kara", "Kadir Arslan", "Bahar Özkan", "Levent Polat", "Zehra Şimşek",
        "Koray Demir", "Sibel Kaya", "Selçuk Erdem", "Pelin Yıldız", "Deniz Kaan", "Ece Acar"
    }},
    { "Bergama", new List<string>{
        "Leyla Arı", "Oğuzhan Şimşek", "Sibel Doğan", "Gökhan Tekin",
        "Ahmet Polat", "Elif Özkan", "Mehmet Yıldırım", "Derya Kılıç", "Can Demirtaş", "Zeynep Aksoy",
        "Serdar Şahin", "Sevda Kaya", "Cem Doğan", "Merve Çetin", "Onur Kaplan", "Ece Akbulut",
        "Furkan Aydın", "Buse Korkmaz", "Kerem Yılmaz", "Nazlı Demir", "Emre Arslan", "Seda Özdemir",
        "Volkan Tuncer", "Selin Erdem", "Murat Akın", "Gamze Kaan", "İsmail Şen", "Cansu Polat",
        "Barış Doğan", "Zehra Acar", "Kemal Yıldız", "Nilay Kaya", "Fatih Tekin", "Melis Şimşek",
        "Erdem Yalçın", "Bahar Özkan", "Serkan Kılıç", "Pelin Demirtaş", "Okan Arslan", "Gamze Aydın"
    }},
    { "İzmir", new List<string>{
        "Ahmet Demir", "Ayşe Yılmaz", "Fatma Kaya", "Mehmet Şahin", "Elif Arslan", "Hakan Doğan",
        "Selin Özkan", "Deniz Kılıç", "Ece Polat", "Serkan Aksoy", "Zehra Yıldırım", "Murat Çetin",
        "Merve Kaplan", "Ali Acar", "Gamze Korkmaz", "Barış Özdemir", "Seda Yalçın", "Mustafa Şimşek",
        "Derya Kara", "Okan Tekin", "Funda Yılmaz", "Volkan Demirtaş", "Sibel Kaya", "Tolga Arı",
        "Nazlı Doğan", "Burak Polat", "Selma Akbulut", "Cihan Şahin", "Büşra Özkan", "Onur Kılıç",
        "Zeynep Kaplan", "Kemal Yıldırım", "Sevgi Çetin", "Yusuf Acar", "Nilay Korkmaz", "Fatih Özdemir",
        "Gülşah Şimşek", "Erdem Yalçın", "Melis Demir", "Ahmet Kaya"
    }},
    { "Bornova", new List<string>{
        "Burak Demir", "Seda Yılmaz", "Emre Kaya", "Bahar Arslan", "Tolga Şahin", "Nazlı Demirtaş",
        "Cem Özkan", "Elif Doğan", "Mert Polat", "Dilan Kılıç", "Oğuzhan Yıldırım", "Gamze Özkan",
        "Serkan Kılıç", "Ayşe Demir", "Merve Aksoy", "Hakan Yalçın", "Selin Kara", "Deniz Polat",
        "Ece Doğan", "Onur Yıldırım", "Pelin Arslan", "Fırat Özkan", "Sevda Kaya", "Eren Demir",
        "Buse Kılıç", "Kerem Polat", "Nazlı Şahin", "Cihan Demirtaş", "Gamze Yıldırım", "Ali Kaya",
        "Melis Doğan", "Volkan Aksoy", "Sibel Demir", "Murat Yıldırım", "Selin Polat", "Onur Kaplan",
        "Zeynep Özkan", "Kemal Yalçın", "Sevgi Demir", "Yusuf Kılıç"
    }},
    { "Karşıyaka", new List<string>{
        "Cem Özkan", "Zeynep Kılıç", "Mert Acar", "İpek Demirtaş", "Ömer Şahin", "Dilan Arslan",
        "Engin Polat", "Ceyda Kaya", "Oğuzhan Yıldırım", "Gizem Aksoy", "Hüseyin Doğan", "Pelin Korkmaz",
        "Fırat Yılmaz", "Sevda Özkan", "Eren Şimşek", "Burcu Kaplan", "Serhat Demir", "Şebnem Çetin",
        "Baran Akbulut", "Gamze Polat", "İsmail Yalçın", "Cansu Kara", "Volkan Tekin", "Selin Doğan",
        "Murat Kılıç", "Aslı Acar", "Emre Özdemir", "Merve Şahin", "Halil Kaya", "Derya Polat",
        "Kadir Arslan", "Bahar Özkan", "Levent Polat", "Zehra Şimşek", "Koray Demir", "Sibel Kaya",
        "Selçuk Erdem", "Pelin Yıldız", "Deniz Kaan", "Ece Acar"
    }},
    { "Konak", new List<string>{
        "Ahmet Şimşek", "Ayşe Kaya", "Fatma Özkan", "Mehmet Polat", "Elif Yıldırım", "Hakan Aksoy",
        "Selin Demirtaş", "Deniz Doğan", "Ece Kılıç", "Serkan Kaplan", "Zehra Arslan", "Murat Çetin",
        "Merve Yıldırım", "Ali Şahin", "Gamze Acar", "Barış Özkan", "Seda Doğan", "Mustafa Yılmaz",
        "Derya Korkmaz", "Okan Akbulut", "Funda Demir", "Volkan Tekin", "Sibel Polat", "Tolga Kaya",
        "Nazlı Özkan", "Burak Kılıç", "Selma Yıldırım", "Cihan Aksoy", "Büşra Demirtaş", "Onur Doğan",
        "Zeynep Kaplan", "Kemal Şimşek", "Sevgi Polat", "Yusuf Kaya", "Nilay Özkan", "Fatih Demir",
        "Gülşah Yıldırım", "Erdem Akbulut", "Melis Doğan", "Ahmet Kılıç"
    }},
    { "Çiğli", new List<string>{
        "Cem Yıldırım", "Zeynep Doğan", "Mert Kaplan", "İpek Aksoy", "Ömer Polat", "Dilan Kaya",
        "Engin Demir", "Ceyda Yalçın", "Oğuzhan Kılıç", "Gizem Özkan", "Hüseyin Yılmaz", "Pelin Şahin",
        "Fırat Arslan", "Sevda Çetin", "Eren Akbulut", "Burcu Doğan", "Serhat Polat", "Şebnem Kaya",
        "Baran Özkan", "Gamze Kılıç", "İsmail Demirtaş", "Cansu Yıldırım", "Volkan Doğan", "Selin Kaplan",
        "Murat Aksoy", "Aslı Polat", "Emre Yalçın", "Merve Kılıç", "Halil Doğan", "Derya Özkan",
        "Kadir Yılmaz", "Bahar Şahin", "Levent Arslan", "Zehra Kaya", "Koray Demir", "Sibel Polat",
        "Selçuk Kılıç", "Pelin Doğan", "Deniz Kaplan", "Ece Yıldırım"
    }},
    { "Balçova", new List<string>{
        "Ahmet Aksoy", "Ayşe Polat", "Fatma Kaya", "Mehmet Doğan", "Elif Yıldırım", "Hakan Özkan",
        "Selin Şahin", "Deniz Arslan", "Ece Demirtaş", "Serkan Kılıç", "Zehra Kaplan", "Murat Yıldırım",
        "Merve Özkan", "Ali Doğan", "Gamze Polat", "Barış Kaya", "Seda Demir", "Mustafa Şahin",
        "Derya Aksoy", "Okan Polat", "Funda Kılıç", "Volkan Doğan", "Sibel Özkan", "Tolga Yıldırım",
        "Nazlı Demirtaş", "Burak Yalçın", "Selma Özkan", "Cihan Polat", "Büşra Kaya", "Onur Doğan",
        "Zeynep Kılıç", "Kemal Demirtaş", "Sevgi Yalçın", "Yusuf Özkan", "Nilay Polat", "Fatih Kaya",
        "Gülşah Demir", "Erdem Yıldırım", "Melis Özkan", "Ahmet Kılıç"
    }},
    { "Bayraklı", new List<string>{
        "Burak Yılmaz", "Seda Demir", "Emre Kaya", "Bahar Özkan", "Tolga Kılıç", "Nazlı Yıldırım",
        "Cem Demirtaş", "Elif Polat", "Mert Doğan", "Dilan Şahin", "Oğuzhan Kaya", "Gamze Yıldırım",
        "Serkan Özkan", "Ayşe Yalçın", "Merve Kılıç", "Hakan Doğan", "Selin Polat", "Deniz Arslan",
        "Ece Demir", "Onur Yılmaz", "Pelin Doğan", "Fırat Kılıç", "Sevda Özkan", "Eren Polat",
        "Buse Yıldırım", "Kerem Özkan", "Nazlı Kılıç", "Cihan Yalçın", "Gamze Özkan", "Ali Demir",
        "Melis Polat", "Volkan Yıldırım", "Sibel Demirtaş", "Murat Özkan", "Selin Doğan", "Onur Kılıç",
        "Zeynep Polat", "Kemal Yıldırım", "Sevgi Doğan", "Yusuf Özkan"
    }},
    { "Gaziemir", new List<string>{
        "Cem Demir", "Zeynep Kaya", "Mert Şahin", "İpek Polat", "Ömer Yalçın", "Dilan Özkan",
        "Engin Doğan", "Ceyda Kılıç", "Oğuzhan Kaplan", "Gizem Arslan", "Hüseyin Demirtaş", "Pelin Yıldırım",
        "Fırat Polat", "Sevda Aksoy", "Eren Doğan", "Burcu Yıldırım", "Serhat Özkan", "Şebnem Kılıç",
        "Baran Kaplan", "Gamze Arslan", "İsmail Demirtaş", "Cansu Yıldırım", "Volkan Polat", "Selin Doğan",
        "Murat Özkan", "Aslı Kılıç", "Emre Kaplan", "Merve Arslan", "Halil Demir", "Derya Yalçın",
        "Kadir Özkan", "Bahar Kılıç", "Levent Doğan", "Zehra Kaplan", "Koray Polat", "Sibel Yıldırım",
        "Selçuk Demirtaş", "Pelin Özkan", "Deniz Kılıç", "Ece Kaplan"
    }},
    { "Karabağlar", new List<string>{
        "Ahmet Polat", "Ayşe Doğan", "Fatma Kılıç", "Mehmet Yalçın", "Elif Özkan", "Hakan Kaplan",
        "Selin Demirtaş", "Deniz Arslan", "Ece Yıldırım", "Serkan Özkan", "Zehra Polat", "Murat Kaya",
        "Merve Doğan", "Ali Kılıç", "Gamze Yıldırım", "Barış Özkan", "Seda Demirtaş", "Mustafa Arslan",
        "Derya Kaplan", "Okan Yıldırım", "Funda Polat", "Volkan Doğan", "Sibel Özkan", "Tolga Kılıç",
        "Nazlı Demirtaş", "Burak Yıldırım", "Selma Özkan", "Cihan Polat", "Büşra Kaya", "Onur Doğan",
        "Zeynep Kılıç", "Kemal Demirtaş", "Sevgi Yıldırım", "Yusuf Özkan", "Nilay Polat", "Fatih Kaya",
        "Gülşah Demir", "Erdem Yıldırım", "Melis Özkan", "Ahmet Kılıç"
    }},
    { "Narlıdere", new List<string>{
        "Cem Yalçın", "Zeynep Polat", "Mert Özkan", "İpek Doğan", "Ömer Kılıç", "Dilan Kaplan",
        "Engin Demirtaş", "Ceyda Yıldırım", "Oğuzhan Özkan", "Gizem Polat", "Hüseyin Kaya", "Pelin Doğan",
        "Fırat Kılıç", "Sevda Özkan", "Eren Polat", "Burcu Yalçın", "Serhat Doğan", "Şebnem Kılıç",
        "Baran Kaplan", "Gamze Demirtaş", "İsmail Yıldırım", "Cansu Özkan", "Volkan Doğan", "Selin Polat",
        "Murat Kılıç", "Aslı Demirtaş", "Emre Yalçın", "Merve Özkan", "Halil Doğan", "Derya Kılıç",
        "Kadir Polat", "Bahar Yıldırım", "Levent Özkan", "Zehra Doğan", "Koray Kılıç", "Sibel Kaplan",
        "Selçuk Demirtaş", "Pelin Yıldız", "Deniz Özkan", "Ece Doğan"
    }},
    { "Buca", new List<string>{
        "Ahmet Demirtaş", "Ayşe Yıldırım", "Fatma Polat", "Mehmet Doğan", "Elif Kılıç", "Hakan Özkan",
        "Selin Kaplan", "Deniz Demir", "Ece Yıldırım", "Serkan Polat", "Zehra Doğan", "Murat Kılıç",
        "Merve Özkan", "Ali Yıldırım", "Gamze Polat", "Barış Doğan", "Seda Kılıç", "Mustafa Özkan",
        "Derya Yıldırım", "Okan Polat", "Funda Doğan", "Volkan Kılıç", "Sibel Özkan", "Tolga Yıldırım",
        "Nazlı Demirtaş", "Burak Özkan", "Selma Yıldırım", "Cihan Doğan", "Büşra Kılıç", "Onur Özkan",
        "Zeynep Yıldırım", "Kemal Polat", "Sevgi Doğan", "Yusuf Kılıç", "Nilay Özkan", "Fatih Yıldırım",
        "Gülşah Demir", "Erdem Polat", "Melis Doğan", "Ahmet Yıldırım"
    }},
    { "Seferihisar", new List<string>{
        "Ali Polat", "Ayşe Demir", "Fatma Yıldırım", "Mehmet Özkan", "Elif Kılıç", "Hakan Doğan",
        "Selin Kaya", "Deniz Polat", "Ece Doğan", "Serkan Yıldırım", "Zehra Özkan", "Murat Kılıç",
        "Merve Demir", "Ali Yıldırım", "Gamze Özkan", "Barış Polat", "Seda Yıldırım", "Mustafa Doğan",
        "Derya Kaya", "Okan Demirtaş", "Funda Özkan", "Volkan Yıldırım", "Sibel Doğan", "Tolga Özkan",
        "Nazlı Yıldırım", "Burak Doğan", "Selma Polat", "Cihan Yıldırım", "Büşra Demir", "Onur Polat",
        "Zeynep Doğan", "Kemal Yıldırım", "Sevgi Özkan", "Yusuf Demir", "Nilay Polat", "Fatih Yıldırım",
        "Gülşah Özkan", "Erdem Doğan", "Melis Yıldırım", "Ahmet Polat"
    }},
     { "Urla", new List<string>{
    "Ahmet Kaya", "Ayşe Demir", "Fatma Yıldırım", "Mehmet Polat", "Elif Özkan", "Hakan Yıldırım",
    "Selin Doğan", "Deniz Polat", "Ece Kaya", "Serkan Yıldırım", "Zehra Özkan", "Murat Doğan",
    "Merve Yıldırım", "Ali Polat", "Gamze Demir", "Barış Kılıç", "Seda Özkan", "Mustafa Doğan",
    "Derya Yıldırım", "Okan Polat", "Funda Kaya", "Volkan Yıldırım", "Sibel Doğan", "Tolga Özkan",
    "Nazlı Demirtaş", "Burak Yıldırım", "Selma Özkan", "Cihan Demir", "Büşra Polat", "Onur Doğan",
    "Zeynep Kılıç", "Kemal Demirtaş", "Sevgi Yıldırım", "Yusuf Polat", "Nilay Doğan", "Fatih Yıldırım",
    "Gülşah Polat", "Erdem Doğan", "Melis Yıldırım", "Ahmet Kılıç"
    }},
     { "Foça", new List<string>{
    "Cem Demirtaş", "Zeynep Yıldırım", "Mert Kaya", "İpek Özkan", "Ömer Polat", "Dilan Doğan",
    "Engin Yalçın", "Ceyda Yıldırım", "Oğuzhan Kılıç", "Gizem Polat", "Hüseyin Özkan", "Pelin Yıldırım",
    "Fırat Demir", "Sevda Kaya", "Eren Şahin", "Burcu Demirtaş", "Serhat Yalçın", "Şebnem Özkan",
    "Baran Demir", "Gamze Yıldırım", "İsmail Polat", "Cansu Yıldırım", "Volkan Demir", "Selin Özkan",
    "Murat Yıldırım", "Aslı Polat", "Emre Yıldırım", "Merve Demir", "Halil Polat", "Derya Yıldırım",
    "Kadir Özkan", "Bahar Yıldırım", "Levent Demir", "Zehra Polat", "Koray Yıldırım", "Sibel Demir",
    "Selçuk Yıldırım", "Pelin Demir", "Deniz Yıldırım", "Ece Polat"
} },
{ "Dikili", new List<string>{
    "Ahmet Özkan", "Ayşe Yıldırım", "Fatma Kaya", "Mehmet Doğan", "Elif Kılıç", "Hakan Yıldırım",
    "Selin Kılıç", "Deniz Özkan", "Ece Yıldırım", "Serkan Polat", "Zehra Doğan", "Murat Yıldırım",
    "Merve Kılıç", "Ali Doğan", "Gamze Yıldırım", "Barış Özkan", "Seda Demir", "Mustafa Polat",
    "Derya Yıldırım", "Okan Kılıç", "Funda Doğan", "Volkan Yıldırım", "Sibel Polat", "Tolga Demirtaş",
    "Nazlı Yıldırım", "Burak Özkan", "Selma Kılıç", "Cihan Yıldırım", "Büşra Doğan", "Onur Polat",
    "Zeynep Yıldırım", "Kemal Kılıç", "Sevgi Özkan", "Yusuf Yıldırım", "Nilay Demir", "Fatih Polat",
    "Gülşah Demir", "Erdem Yıldırım", "Melis Özkan", "Ahmet Kılıç"
} },
{ "Menderes", new List<string>{
    "Cem Kaya", "Zeynep Yıldırım", "Mert Polat", "İpek Doğan", "Ömer Kılıç", "Dilan Kaplan",
    "Engin Yıldırım", "Ceyda Özkan", "Oğuzhan Polat", "Gizem Yıldırım", "Hüseyin Demirtaş", "Pelin Kılıç",
    "Fırat Yıldırım", "Sevda Özkan", "Eren Kaplan", "Burcu Yıldırım", "Serhat Demir", "Şebnem Kılıç",
    "Baran Özkan", "Gamze Demirtaş", "İsmail Yıldırım", "Cansu Özkan", "Volkan Kılıç", "Selin Demirtaş",
    "Murat Yıldırım", "Aslı Özkan", "Emre Yıldırım", "Merve Kılıç", "Halil Doğan", "Derya Özkan",
    "Kadir Yıldırım", "Bahar Demirtaş", "Levent Yıldırım", "Zehra Doğan", "Koray Kılıç", "Sibel Kaplan",
    "Selçuk Demirtaş", "Pelin Özkan", "Deniz Demirtaş", "Ece Yıldırım"
} },
{ "Torbalı", new List<string>{
    "Ahmet Yıldırım", "Ayşe Demirtaş", "Fatma Özkan", "Mehmet Kılıç", "Elif Yıldırım", "Hakan Polat",
    "Selin Doğan", "Deniz Yıldırım", "Ece Özkan", "Serkan Kılıç", "Zehra Demirtaş", "Murat Yıldırım",
    "Merve Polat", "Ali Demirtaş", "Gamze Yıldırım", "Barış Özkan", "Seda Yıldırım", "Mustafa Özkan",
    "Derya Polat", "Okan Yıldırım", "Funda Özkan", "Volkan Demirtaş", "Sibel Yıldırım", "Tolga Polat",
    "Nazlı Yıldırım", "Burak Demirtaş", "Selma Polat", "Cihan Yıldırım", "Büşra Özkan", "Onur Demirtaş",
    "Zeynep Polat", "Kemal Yıldırım", "Sevgi Özkan", "Yusuf Demirtaş", "Nilay Yıldırım", "Fatih Özkan",
    "Gülşah Demirtaş", "Erdem Yıldırım", "Melis Özkan", "Ahmet Demirtaş"
} },
};
        // Her servis için bir kez oluşturulmuş bilgiler formu tutulacak
        private Dictionary<string, bilgiler> bilgilerFormlari = new Dictionary<string, bilgiler>();
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Servis listesini comboBox1'e ekle
            comboBox1.Items.AddRange(new object[]
            {
                "Menemen", "Aliağa", "Bergama", "İzmir", "Bornova", "Karşıyaka", "Konak", "Çiğli", "Balçova", "Bayraklı",
                "Gaziemir", "Karabağlar", "Narlıdere", "Buca", "Seferihisar", "Urla", "Foça", "Dikili", "Menderes", "Torbalı"
            });

            // Event bağlamaları
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            btnServiseBinis.Click += async (s, e) => await ButonaBasildiAsync("Servise Biniş", btnServiseBinis);
            btnFabrikayaGiris.Click += async (s, e) => await ButonaBasildiAsync("Fabrikaya Giriş", btnFabrikayaGiris);
            btnFabrikadanCikis.Click += async (s, e) => await ButonaBasildiAsync("Fabrikadan Çıkış", btnFabrikadanCikis);
            btnServiseDonus.Click += async (s, e) => await ButonaBasildiAsync("Servise Dönüş", btnServiseDonus);

            btnAnaSayfa.Click += btnAnaSayfa_Click;
            btnListe.Click += btnListe_Click;
            btnYedegeAl.Click += btnYedegeAl_Click;
            cBoxYedekListe.SelectedIndexChanged += cBoxYedekListe_SelectedIndexChanged;

            timerSaat.Tick += timerSaat_Tick;
            timerSaat.Interval = 1000;
            timerSaat.Start();
        }
        private void timerSaat_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = "Saat : " + DateTime.Now.ToString("HH:mm:ss");
        }
        private Dictionary<string, List<string>> servisOnerileri = new Dictionary<string, List<string>>()
{
    { "Menemen", new List<string> { "Gaziemir", "Menderes", "Torbalı", "Buca" } },
    { "Aliağa", new List<string> { "Bergama", "Dikili" } },
    { "Bornova", new List<string> { "Buca", "Gaziemir", "Torbalı", "Menderes" } },
    { "Karşıyaka", new List<string> { "Buca", "Gaziemir", "Torbalı" } },
    { "Konak", new List<string> { "Buca", "Gaziemir", "Torbalı" } },
    { "Çiğli", new List<string> { "Karşıyaka", "Bornova", "Konak" } },
    { "Balçova", new List<string> { "Buca", "Gaziemir", "Torbalı" } },
    { "Bayraklı", new List<string> { "Buca", "Gaziemir", "Torbalı" } },
    { "Gaziemir", new List<string> { "Buca", "Torbalı" } },
    { "Karabağlar", new List<string> { "Buca", "Torbalı", "Menderes" } },
    { "Narlıdere", new List<string> { "Buca", "Gaziemir", "Seferihisar" } },
    { "Buca", new List<string> { "Gaziemir", "Seferihisar", "Torbalı" } },
    { "Seferihisar", new List<string> { "Torbalı" } },
    { "Urla", new List<string> { "Seferihisar", "Torbalı" } },
    { "Dikili", new List<string> { "Bergama" } },
    { "Menderes", new List<string> { "Torbalı", "Seferihisar" } }
};
        private async Task ButonaBasildiAsync(string hareketTipi, Button btn)
        {
            string secilenServis = comboBox1.SelectedItem?.ToString();
            string secilenIsim = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilenServis) || string.IsNullOrEmpty(secilenIsim))
            {
                MessageBox.Show("Lütfen servis ve çalışan seçiniz.");
                return;
            }

            int mevcutKontenjan = DatabaseHelper.KontenjanGetir(secilenServis);
            string tarih = DateTime.Now.ToString("dd.MM.yyyy");
            string saat = DateTime.Now.ToString("HH:mm:ss");
            string eskiYazi = btn.Text;

            btn.Text = $"{secilenIsim}\n{tarih} {saat}\n{hareketTipi}";

            bool girisBasarili = true;

            if (hareketTipi == "Yedeğe Al")
            {
                // Yedek alındı - Sarı panel
                panelCihaz.BackColor = Color.Gold;
                lblCihazEkran.BackColor = Color.Gold;
                lblCihazEkran.Text = $"{secilenIsim}\nYedek Listeye Alındı";
                lblCihazEkran.ForeColor = Color.Black;

                new SoundPlayer(@"Sesler/yellow_warning.wav").Play();

                lblServisOnerisi.Text = "";
                lblServisOnerisi.Visible = false;

                // Yedek listeye ekle
                DatabaseHelper.YedekListeyeEkle(secilenServis, secilenIsim, DateTime.Now);
            }
            else if (hareketTipi == "Servise Biniş" && mevcutKontenjan <= 0)
            {
                // Kontenjan doldu - Kırmızı panel
                panelCihaz.BackColor = Color.Red;
                lblCihazEkran.BackColor = Color.Red;
                lblCihazEkran.Text = $"Giriş Başarısız\nKontenjan Doldu!";
                lblCihazEkran.ForeColor = Color.White;

                new SoundPlayer(@"Sesler/red_error.wav").Play();

                if (servisOnerileri.ContainsKey(secilenServis))
                {
                    List<string> oneriler = servisOnerileri[secilenServis];
                    string mesaj = "Önerilen Servisler: " + string.Join(", ", oneriler);
                    lblServisOnerisi.Text = mesaj;
                    lblServisOnerisi.Visible = true;
                }
                else
                {
                    lblServisOnerisi.Text = "";
                    lblServisOnerisi.Visible = false;
                }

                girisBasarili = false;
            }
            else
            {
                // Başarılı giriş - Yeşil panel
                panelCihaz.BackColor = Color.Green;
                lblCihazEkran.BackColor = Color.Green;
                lblCihazEkran.Text = $"{secilenIsim}\nGiriş Başarılı";
                lblCihazEkran.ForeColor = Color.White;

                new SoundPlayer(@"Sesler/green_ding.wav").Play();

                lblServisOnerisi.Text = "";
                lblServisOnerisi.Visible = false;

                // Database kaydı ekle/güncelle
                TimeSpan saatTs = DateTime.Now.TimeOfDay;
                DatabaseHelper.KayitEkleGuncelle(secilenIsim, secilenServis, DateTime.Now.Date, hareketTipi, saatTs);
            }

            lblSaat.Text = "Saat: " + saat;

            await Task.Delay(4000);

            // Panel ve ekranı sıfırla
            panelCihaz.BackColor = Color.Gray;
            lblCihazEkran.BackColor = Color.Black;
            lblCihazEkran.ForeColor = Color.White;
            lblCihazEkran.Text = "📷 Kart Okutun";

            lblServisOnerisi.Text = "";
            lblServisOnerisi.Visible = false;

            btn.Text = eskiYazi;

            if (!girisBasarili)
                return;

            // Kontenjan güncelleme sadece diğer hareket tipleri için
            if (hareketTipi == "Servise Biniş")
                DatabaseHelper.KontenjanGuncelle(secilenServis, mevcutKontenjan - 1);
            else if (hareketTipi == "Fabrikaya Giriş")
                DatabaseHelper.KontenjanGuncelle(secilenServis, mevcutKontenjan + 1);
            else if (hareketTipi == "Servise Dönüş")
                DatabaseHelper.KontenjanGuncelle(secilenServis, mevcutKontenjan - 1);

            // Yeni kontenjanı göster
            int yeniKontenjan = DatabaseHelper.KontenjanGetir(secilenServis);
            if (yeniKontenjan >= 0)
            {
                lblKontenjanDurumu.Text = $"Kalan kontenjan: {yeniKontenjan}";
                lblKontenjanDurumu.ForeColor = yeniKontenjan == 0 ? Color.Red : Color.Green;
            }

            // Bilgiler formunu aç veya getir
            if (!bilgilerFormlari.ContainsKey(secilenServis) || bilgilerFormlari[secilenServis].IsDisposed)
            {
                bilgilerFormlari[secilenServis] = new bilgiler(secilenServis);
                bilgilerFormlari[secilenServis].Show();
            }
            else
            {
                bilgilerFormlari[secilenServis].BringToFront();
            }

            bilgilerFormlari[secilenServis].YeniKayitEkle(secilenIsim, tarih, secilenServis, saat, hareketTipi);
        }

        // Servis seçimi değiştiğinde çalışanları doldur
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string secilenServis = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(secilenServis)) return;

            SonSecimler.SonServis = secilenServis;

            if (servisCalisanlari.ContainsKey(secilenServis))
            {
                comboBox2.Items.AddRange(servisCalisanlari[secilenServis].ToArray());

                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = 0;
                    SonSecimler.SonKisi = comboBox2.SelectedItem?.ToString();
                }
            }

            int kontenjan = DatabaseHelper.KontenjanGetir(secilenServis);
            if (kontenjan >= 0)
            {
                lblKontenjanDurumu.Text = $"Kalan kontenjan: {kontenjan}";
                lblKontenjanDurumu.ForeColor = kontenjan == 0 ? Color.Red : Color.Green;
            }
            else
            {
                lblKontenjanDurumu.Text = "Kontenjan bilgisi yok";
                lblKontenjanDurumu.ForeColor = Color.Black;
            }
        }

        // Çalışan seçimi değiştiğinde son kişi kaydet
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                SonSecimler.SonKisi = comboBox2.SelectedItem.ToString();
            }
        }

        // Ana sayfa butonu
        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Program.AnaForm.Show();
            Program.AnaForm.BringToFront();
            this.Hide();
        }

        // Form yüklendiğinde
        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.White;
                    label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }

            lblTarih.Text = DateTime.Now.ToString("dd.MM.yyyy");

            // Önceki seçimleri yükle
            if (!string.IsNullOrEmpty(SonSecimler.SonServis))
            {
                comboBox1.SelectedItem = SonSecimler.SonServis;

                if (servisCalisanlari.ContainsKey(SonSecimler.SonServis))
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(servisCalisanlari[SonSecimler.SonServis].ToArray());

                    if (!string.IsNullOrEmpty(SonSecimler.SonKisi) &&
                        comboBox2.Items.Contains(SonSecimler.SonKisi))
                    {
                        comboBox2.SelectedItem = SonSecimler.SonKisi;
                    }
                }
            }

            panelCihaz.BackColor = Color.Gray;
            lblCihazEkran.BackColor = Color.Black;
            lblCihazEkran.ForeColor = Color.White;
            lblCihazEkran.Text = "📷 Kart Okutun";

            // Başlangıçta kontenjan gösterimi (eğer servis seçiliyse)
            string secilenServis = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(secilenServis))
            {
                int kontenjan = DatabaseHelper.KontenjanGetir(secilenServis);
                if (kontenjan >= 0)
                {
                    lblKontenjan.Text = $"Kalan kontenjan: {kontenjan}";
                    lblKontenjan.ForeColor = kontenjan == 0 ? Color.Red : Color.Green;
                }
                else
                {
                    lblKontenjan.Text = "Kontenjan bilgisi yok";
                    lblKontenjan.ForeColor = Color.Black;
                }
            }
        }
        private void btnListe_Click(object sender, EventArgs e)
        {
            string secilenServis = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(secilenServis))
            {
                MessageBox.Show("Lütfen bir servis seçiniz.");
                return;
            }

            if (!bilgilerFormlari.ContainsKey(secilenServis) || bilgilerFormlari[secilenServis].IsDisposed)
            {
                bilgilerFormlari[secilenServis] = new bilgiler(secilenServis);
                bilgilerFormlari[secilenServis].Show();
            }
            else
            {
                bilgilerFormlari[secilenServis].BringToFront();
            }
        }

        private void btnServiseBinis_Click(object sender, EventArgs e)
        {
            // Butona tıklandığında yapılacak işlemler
            // Örnek olarak ButonaBasildiAsync'i çağırılabilir
            _ = ButonaBasildiAsync("Servise Biniş", (Button)sender);
        }

        // Yedeğe Al butonu
        private async void btnYedegeAl_Click(object sender, EventArgs e)
        {
            string secilenIsim = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilenIsim))
            {
                MessageBox.Show("Lütfen çalışan seçiniz.");
                return;
            }

            if (!cBoxYedekListe.Items.Contains(secilenIsim))
            {
                cBoxYedekListe.Items.Add(secilenIsim);

                // ButonaBasildiAsync'i "Yedeğe Al" hareket tipi ile çağır, btn parametresi olarak buradaki butonu kullanılır
                await ButonaBasildiAsync("Yedeğe Al", (Button)sender);

                // isteğe bağlı ilgilendirme mesajı 
                MessageBox.Show($"{secilenIsim} yedek listeye alındı.");
            }
            else
            {
                MessageBox.Show($"{secilenIsim} zaten yedek listede.");
            }
        }

        // Yedek liste seçim değiştiğinde
        private void cBoxYedekListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxYedekListe.SelectedItem != null)
            {
                MessageBox.Show($"{cBoxYedekListe.SelectedItem} yedek listeden seçildi.");
            }
        }

        private void lblTarih_Click(object sender, EventArgs e)
        {
            // boş
        }

        private void panelCihaz_Paint(object sender, PaintEventArgs e)
        {
            // boş
        }
    }
}