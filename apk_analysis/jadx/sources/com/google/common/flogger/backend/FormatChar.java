package com.google.common.flogger.backend;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Init of enum field 'DECIMAL' uses external variables
	at jadx.core.dex.visitors.EnumVisitor.createEnumFieldByConstructor(EnumVisitor.java:485)
	at jadx.core.dex.visitors.EnumVisitor.processEnumFieldByField(EnumVisitor.java:399)
	at jadx.core.dex.visitors.EnumVisitor.processEnumFieldByWrappedInsn(EnumVisitor.java:364)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromFilledArray(EnumVisitor.java:349)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromInsn(EnumVisitor.java:284)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromInvoke(EnumVisitor.java:315)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromInsn(EnumVisitor.java:288)
	at jadx.core.dex.visitors.EnumVisitor.convertToEnum(EnumVisitor.java:153)
	at jadx.core.dex.visitors.EnumVisitor.visit(EnumVisitor.java:102)
 */
/* JADX WARN: Failed to restore enum class, 'enum' modifier and super class removed */
/* JADX INFO: loaded from: classes2.dex */
public final class FormatChar {
    private static final /* synthetic */ FormatChar[] $VALUES;
    public static final FormatChar DECIMAL;
    public static final FormatChar EXPONENT;
    public static final FormatChar EXPONENT_HEX;
    public static final FormatChar FLOAT;
    public static final FormatChar GENERAL;
    public static final FormatChar HEX;
    private static final FormatChar[] MAP;
    public static final FormatChar OCTAL;
    private final int allowedFlags;
    private final String defaultFormatString;
    private final char formatChar;
    private final FormatType type;
    public static final FormatChar STRING = new FormatChar("STRING", 0, 's', FormatType.GENERAL, "-#", true);
    public static final FormatChar BOOLEAN = new FormatChar("BOOLEAN", 1, 'b', FormatType.BOOLEAN, "-", true);
    public static final FormatChar CHAR = new FormatChar("CHAR", 2, 'c', FormatType.CHARACTER, "-", true);

    private static int indexOf(char c) {
        return (c | ' ') - 97;
    }

    private static boolean isLowerCase(char c) {
        return (c & ' ') != 0;
    }

    private static /* synthetic */ FormatChar[] $values() {
        return new FormatChar[]{STRING, BOOLEAN, CHAR, DECIMAL, OCTAL, HEX, FLOAT, EXPONENT, GENERAL, EXPONENT_HEX};
    }

    public static FormatChar valueOf(String str) {
        return (FormatChar) Enum.valueOf(FormatChar.class, str);
    }

    public static FormatChar[] values() {
        return (FormatChar[]) $VALUES.clone();
    }

    static {
        FormatType formatType = FormatType.INTEGRAL;
        DECIMAL = new FormatChar("DECIMAL", 3, 'd', formatType, "-0+ ,(", false);
        OCTAL = new FormatChar("OCTAL", 4, 'o', formatType, "-#0(", false);
        HEX = new FormatChar("HEX", 5, 'x', formatType, "-#0(", true);
        FormatType formatType2 = FormatType.FLOAT;
        FLOAT = new FormatChar("FLOAT", 6, 'f', formatType2, "-#0+ ,(", false);
        EXPONENT = new FormatChar("EXPONENT", 7, 'e', formatType2, "-#0+ (", true);
        GENERAL = new FormatChar("GENERAL", 8, 'g', formatType2, "-0+ ,(", true);
        EXPONENT_HEX = new FormatChar("EXPONENT_HEX", 9, 'a', formatType2, "-#0+ ", true);
        $VALUES = $values();
        MAP = new FormatChar[26];
        for (FormatChar formatChar : values()) {
            MAP[indexOf(formatChar.getChar())] = formatChar;
        }
    }

    public static FormatChar of(char c) {
        FormatChar formatChar = MAP[indexOf(c)];
        if (isLowerCase(c)) {
            return formatChar;
        }
        if (formatChar == null || !formatChar.hasUpperCaseVariant()) {
            return null;
        }
        return formatChar;
    }

    private FormatChar(String str, int i, char c, FormatType formatType, String str2, boolean z) {
        super(str, i);
        this.formatChar = c;
        this.type = formatType;
        this.allowedFlags = FormatOptions.parseValidFlags(str2, z);
        this.defaultFormatString = "%" + c;
    }

    public char getChar() {
        return this.formatChar;
    }

    public FormatType getType() {
        return this.type;
    }

    int getAllowedFlags() {
        return this.allowedFlags;
    }

    private boolean hasUpperCaseVariant() {
        return (this.allowedFlags & 128) != 0;
    }

    public String getDefaultFormatString() {
        return this.defaultFormatString;
    }
}
