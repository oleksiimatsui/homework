grammar LabCalculator;

compileUnit : expression EOF;
expression:
	LPAREN expression RPAREN													#ParenthesizedExpr

	|operatorToken=(MOD|DIV) LPAREN expression COMA expression RPAREN			#ModordivExpr
	|operatorToken=(MAX|MIN) LPAREN expression COMA expression RPAREN			#MaxorminExpr
	|expression operatorToken=(MULTIPLY|DIVIDE) expression						#MultiplicativeExpr
	|expression operatorToken=(ADD|SUBSTRACT) expression						#AdditiveExpr
	|expression operatorToken=(LESS|GREATER|EQUAL) expression					#LessorgreaterorequalExpr

	|NOT LPAREN expression RPAREN												#NotExpr
	|NUMBER																		#NumberExpr
	|IDENTIFIER																	#IdentifierExpr;

NUMBER : INT ('.' INT)?; 
IDENTIFIER : [a-zA-Z]+ ('0'..'9')+ ;

INT : ('0'..'9')+;

MAX : 'max';
MIN : 'min';
MOD : 'mod';
DIV : 'div';
MULTIPLY : '*';
DIVIDE : '/';
ADD : '+';
SUBSTRACT : '-';

LESS : '<';
GREATER : '>';
EQUAL : '=';
COMA : ',';

NOT : 'not';
LPAREN : '(';
RPAREN : ')';

WS : [ \t\r\n] -> channel(HIDDEN);