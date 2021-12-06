<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output
		method="html"></xsl:output>
	<xsl:template match="/">
		<html>
			<body>
				<table border = "1" width ="100%">
					<xsl:for-each select = "scientists/scientist">
						<tr>
							<td colspan="4">
								<xsl:value-of select = "Name"/>
							</td>
						</tr>

						<xsl:for-each select = "PositionChanges/PositionChange">
							<tr>
								<td>
									<xsl:value-of select = "JoinTime"/>
								</td>
								<td>
									<xsl:value-of select = "Faculty"/>
								</td>
								<td>
									<xsl:value-of select = "Department"/>
								</td>
								<td>
									<xsl:value-of select = "Position"/>
								</td>
							</tr>
						</xsl:for-each>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>