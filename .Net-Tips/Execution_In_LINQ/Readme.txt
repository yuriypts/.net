EF Core supports 3 ways to load related entities:

𝗘𝗮𝗴𝗲𝗿 𝗟𝗼𝗮𝗱𝗶𝗻𝗴 - Fetches related data as part of the initial query.

𝗘𝘅𝗽𝗹𝗶𝗰𝗶𝘁 𝗟𝗼𝗮𝗱𝗶𝗻𝗴 - Loads related data manually only when needed.

𝗟𝗮𝘇𝘆 𝗟𝗼𝗮𝗱𝗶𝗻𝗴 - Defers loading of related data until it’s actually accessed.

You can use the 𝗜𝗻𝗰𝗹𝘂𝗱𝗲 to specify related data to be included in query results.

You can include related data from multiple relationships in a single query.

Additionally, when using Include you can also apply enumerable operations to filter and sort the results.

To load multiple levels of related data by chaining calls utilize 𝗧𝗵𝗲𝗻𝗜𝗻𝗰𝗹𝘂𝗱𝗲.

EF Core also supports automatic eager loading using [𝗔𝘂𝘁𝗼𝗜𝗻𝗰𝗹𝘂𝗱𝗲] attribute or model configuration.