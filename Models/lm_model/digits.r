bits <- function(n,bits, base = 2) {
  orig_No <- n
  quotient <- n%/%base
  remainder <- n%%base
  if ( quotient >= base ) {
      while( quotient >= base ) {
      n <- quotient
      quotient <- n%/%base
      remainder <- c( remainder , n%%base ) } }
  remainder <- c( remainder , quotient )
  return( c( rep( 0 , ( bits - length( remainder ) ) ) , rev( remainder ) ) ) }
