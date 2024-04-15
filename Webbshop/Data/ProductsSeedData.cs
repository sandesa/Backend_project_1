using System;
using Webbshop.Models;

namespace Webbshop.Data
{
	public class ProductsSeedData
	{
		public static async Task InitializeAsync(AppDbContext context)
		{
			if (!context.Products.Any())
			{
				var products = new List<Product>
				{
					new Product
					{
						Name = "Ljusblå t-shirt",
						ImageName = "ljusbla_tshirt.jpg",
						Price = 199m,
						Category = "Kläder",
						Description = "En bekväm och stilren t-shirt tillverkad av mjuk bomullstyg i ljusblå färg."
					},
					new Product
					{
						Name = "Vintage läderarmbandsur",
						ImageName = "vintage_ur.jpg",
						Price = 899m,
						Category = "Accessoarer",
						Description = "Ett elegant och klassiskt armbandsur med läderband och antik stil som passar både vardag och fest."
					},
					new Product
					{
						Name = "Ekologisk kokosnötolja",
						ImageName = "kokosnötolja.jpg",
						Price = 79m,
						Category = "Mat och dryck",
						Description = "Ren ekologisk kokosnötolja av hög kvalitet, perfekt för matlagning, hudvård och hårbehandlingar."
					},
					new Product
					{
						Name = "Trådlösa brusreducerande hörlurar",
						ImageName = "brusreducerande_hörlurar.jpg",
						Price = 1299m,
						Category = "Elektronik",
						Description = "Trådlösa hörlurar med avancerad brusreduceringsteknik för en förstklassig ljudupplevelse utan störande bakgrundsljud."
					},
					new Product
					{
						Name = "Blommig keramikmugg",
						ImageName = "blommig_mugg.jpg",
						Price = 149m,
						Category = "Hem och trädgård",
						Description = "En vacker keramikmugg med handmålad blommönster, perfekt för att njuta av din favoritdryck på ett elegant sätt."
					},
					new Product
					{
						Name = "Fitness Yoga Matta",
						ImageName = "yoga_matta.jpg",
						Price = 299m,
						Category = "Sport och fritid",
						Description = "En tjock och slitstark yogamatta som ger komfort och stabilitet under dina yoga- och träningspass."
					},
					new Product
					{
						Name = "Handgjord läderportfölj",
						ImageName = "läderportfölj.jpg",
						Price = 699m,
						Category = "Accessoarer",
						Description = "En exklusiv handgjord läderportfölj med flera fack för att organisera dina viktiga dokument och tillbehör."
					},
					new Product
					{
						Name = "Ekologisk quinoasallad",
						ImageName = "quinoasallad.jpg",
						Price = 129m,
						Category = "Mat och dryck",
						Description = "En näringsrik och läcker quinoasallad med färska grönsaker och örter, perfekt som en lätt lunch eller sidorätt."
					},
					new Product
					{
						Name = "Smart trådlös laddningsplatta",
						ImageName = "laddningsplatta.jpg",
						Price = 249m,
						Category = "Elektronik",
						Description = "En smidig trådlös laddningsplatta som ger snabb och effektiv laddning för din smartphone eller annan kompatibel enhet."
					},
					new Product
					{
						Name = "Rustik träskärbräda",
						ImageName = "träskärbräda.jpg",
						Price = 199m,
						Category = "Hem och trädgård",
						Description = "En vackert utformad skärbräda tillverkad av hållbart trä, perfekt för att förbereda och servera dina favoriträtter."
					},
					new Product
					{
						Name = "Klassiskt kolsyrat vatten",
						ImageName = "kolsyrat_vatten.jpg",
						Price = 19m,
						Category = "Mat och dryck",
						Description = "Ett friskt och bubblande kolsyrat vatten som passar perfekt som törstsläckare vid alla tillfällen."
					},
					new Product
					{
						Name = "Ergonomisk kontorsstol",
						ImageName = "kontorsstol.jpg",
						Price = 1799m,
						Category = "Hem och trädgård",
						Description = "En ergonomisk kontorsstol med justerbara funktioner för att ge optimal komfort och stöd under långa arbetspass."
					},
					new Product
					{
						Name = "Portabel solcellslampa",
						ImageName = "solcellslampa.jpg",
						Price = 299m,
						Category = "Utomhus",
						Description = "En praktisk och energieffektiv solcellslampa som ger ljus i trädgården eller på campingturen utan behov av eluttag."
					},
					new Product
					{
						Name = "Vegansk chokladkaka",
						ImageName = "chokladkaka.jpg",
						Price = 69m,
						Category = "Mat och dryck",
						Description = "En ljuvligt krämig och smakrik chokladkaka utan animaliska produkter, perfekt för alla chokladälskare."
					},
					new Product
					{
						Name = "Trådlös Bluetooth-högtalare",
						ImageName = "bluetooth_högtalare.jpg",
						Price = 599m,
						Category = "Elektronik",
						Description = "En kraftfull trådlös Bluetooth-högtalare med imponerande ljudkvalitet och lång batteritid för att förgylla ditt musiklyssnande."
					},
					new Product
					{
						Name = "Klassiskt skinnskärp",
						ImageName = "jeansskärp.jpg",
						Price = 99m,
						Category = "Kläder",
						Description = "Ett stilrent och hållbart skinnskärp i klassisk design som kompletterar din outfit på ett elegant sätt."
					},
					new Product
					{
						Name = "Marmorerad keramikvas",
						ImageName = "keramikvas.jpg",
						Price = 249m,
						Category = "Hem och trädgård",
						Description = "En vacker och unik keramikvas med marmorerat mönster, perfekt för att visa upp dina favoritblommor eller dekorativa grenar."
					},
					new Product
					{
						Name = "Energibar med nötter och frön",
						ImageName = "energibar.jpg",
						Price = 29m,
						Category = "Mat och dryck",
						Description = "En näringsrik och mättande energibar packad med hälsosamma nötter, frön och torkad frukt, perfekt som mellanmål eller energikick."
					},
					new Product
					{
						Name = "Trådlös mus",
						ImageName = "trådlös_mus.jpg",
						Price = 149m,
						Category = "Elektronik",
						Description = "En smidig och ergonomisk trådlös mus med precisionsspårning och bekväm grepp, perfekt för arbete och spel."
					},
					new Product
					{
						Name = "Hållbar bomullskasse",
						ImageName = "bomullskasse.jpg",
						Price = 49m,
						Category = "Kläder",
						Description = "En miljövänlig och återanvändbar bomullskasse med snygg design och tillräckligt med utrymme för dina inköp och tillbehör."
					},
					new Product
					{
						Name = "Grönt te med ingefära och citron",
						ImageName = "grönt_te.jpg",
						Price = 79m,
						Category = "Mat och dryck",
						Description = "Ett uppfriskande grönt te med en touch av ingefära och citron, perfekt för att njuta av en lugn stund eller som en uppiggande dryck."
					},
					new Product
					{
						Name = "Resistent träningsgummiband",
						ImageName = "träningsgummiband.jpg",
						Price = 89m,
						Category = "Sport och fritid",
						Description = "Ett slitstarkt och mångsidigt träningsgummiband som erbjuder motstånd för att stärka och forma musklerna under träningspasset."
					},
					new Product
					{
						Name = "Moderna solglasögon",
						ImageName = "solglasögon.jpg",
						Price = 349m,
						Category = "Accessoarer",
						Description = "Eleganta och modernt designade solglasögon med UV-skydd för att skydda dina ögon samtidigt som de ger en stilfull look."
					},
					new Product
					{
						Name = "Konstgjorda krukväxter",
						ImageName = "krukväxter.jpg",
						Price = 199m,
						Category = "Hem och trädgård",
						Description = "Realistiska konstgjorda krukväxter som ger grönska och liv åt ditt hem utan krav på skötsel eller vatten."
					},
					new Product
					{
						Name = "Trådlöst tangentbord och mus set",
						ImageName = "tangentbord_mus_set.jpg",
						Price = 399m,
						Category = "Elektronik",
						Description = "En bekväm och effektiv kombination av trådlöst tangentbord och mus för smidig och trådlös datorkommunikation."
					},
					new Product
					{
						Name = "Ekologiskt avokadoolja",
						ImageName = "avokadoolja.jpg",
						Price = 99m,
						Category = "Mat och dryck",
						Description = "Ren ekologiskt avokadoolja av hög kvalitet, rik på nyttiga fettsyror och perfekt för matlagning och hudvård."
					},
					new Product
					{
						Name = "Trendig ryggsäck i canvas",
						ImageName = "canvas_ryggsäck.jpg",
						Price = 449m,
						Category = "Accessoarer",
						Description = "En trendig och praktisk ryggsäck tillverkad av slitstark canvas med flera fickor och justerbara remmar för maximal bekvämlighet."
					},
					new Product
					{
						Name = "Multifunktionell kökskniv",
						ImageName = "kökskniv.jpg",
						Price = 179m,
						Category = "Hem och trädgård",
						Description = "En skarp och mångsidig kökskniv med ergonomiskt handtag och rostfritt stålblad, perfekt för alla dina matlagningsbehov."
					},
					new Product
					{
						Name = "Energisparande LED-lampa",
						ImageName = "LED-lampa.jpg",
						Price = 69m,
						Category = "Hem och trädgård",
						Description = "En energisnål och miljövänlig LED-lampa som ger starkt och klart ljus med låg strömförbrukning och lång livslängd."
					},
					new Product
					{
						Name = "Ekologiskt havregryn",
						ImageName = "havregryn.jpg",
						Price = 49m,
						Category = "Mat och dryck",
						Description = "Ren ekologiskt havregryn av hög kvalitet, perfekt för en näringsrik och hälsosam frukost eller bakning av läckra bröd och kakor."
					},
				};

				await context.Products.AddRangeAsync(products);
				await context.SaveChangesAsync();
			}
		}
	}
}