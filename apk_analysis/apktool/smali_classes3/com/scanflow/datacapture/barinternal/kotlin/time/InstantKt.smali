.class public abstract Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;
.super Ljava/lang/Object;
.source "Instant.kt"


# static fields
.field private static final POWERS_OF_TEN:[I

.field private static final asciiDigitPositionsInIsoStringAfterYear:[I

.field private static final asciiDigitsInIsoOffsetString:[I

.field private static final colonsInIsoOffsetString:[I


# direct methods
.method public static synthetic $r8$lambda$IkUn2NROTCX2lBvTn4A-V5RmZMI(C)Z
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$lambda$6(C)Z

    move-result p0

    return p0
.end method

.method public static synthetic $r8$lambda$Ue47iscnRYF1ET4bm4NsD_78ozQ(C)Z
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$lambda$0(C)Z

    move-result p0

    return p0
.end method

.method public static synthetic $r8$lambda$VQuIyPyOaYjo_HSMWZ5md5B5WS4(C)Z
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$lambda$4(C)Z

    move-result p0

    return p0
.end method

.method public static synthetic $r8$lambda$YedMVjhOc1GtI8LPd5fqhvafh8s(C)Z
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$lambda$10(C)Z

    move-result p0

    return p0
.end method

.method public static synthetic $r8$lambda$_13rfjrKJh1j1Bat0IdAkLKuo8Q(C)Z
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$lambda$2(C)Z

    move-result p0

    return p0
.end method

.method public static synthetic $r8$lambda$sUF6YZWJqa7URjuTZna1EDa75cQ(C)Z
    .locals 0

    .line 0
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$lambda$8(C)Z

    move-result p0

    return p0
.end method

.method static constructor <clinit>()V
    .locals 2

    const/16 v0, 0xa

    .line 859
    new-array v1, v0, [I

    fill-array-data v1, :array_0

    .line 849
    sput-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->POWERS_OF_TEN:[I

    .line 862
    new-array v0, v0, [I

    fill-array-data v0, :array_1

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->asciiDigitPositionsInIsoStringAfterYear:[I

    const/4 v0, 0x3

    const/4 v1, 0x6

    .line 863
    filled-new-array {v0, v1}, [I

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->colonsInIsoOffsetString:[I

    .line 864
    new-array v0, v1, [I

    fill-array-data v0, :array_2

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->asciiDigitsInIsoOffsetString:[I

    return-void

    :array_0
    .array-data 4
        0x1
        0xa
        0x64
        0x3e8
        0x2710
        0x186a0
        0xf4240
        0x989680
        0x5f5e100
        0x3b9aca00
    .end array-data

    :array_1
    .array-data 4
        0x1
        0x2
        0x4
        0x5
        0x7
        0x8
        0xa
        0xb
        0xd
        0xe
    .end array-data

    :array_2
    .array-data 4
        0x1
        0x2
        0x4
        0x5
        0x7
        0x8
    .end array-data
.end method

.method public static final synthetic access$formatIso(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)Ljava/lang/String;
    .locals 0

    .line 1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->formatIso(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$parseIso(Ljava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;
    .locals 0

    .line 1
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso(Ljava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;

    move-result-object p0

    return-object p0
.end method

.method public static final synthetic access$truncateForErrorMessage(Ljava/lang/CharSequence;I)Ljava/lang/String;
    .locals 0

    .line 1
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->truncateForErrorMessage(Ljava/lang/CharSequence;I)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method private static final formatIso(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)Ljava/lang/String;
    .locals 7

    .line 731
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    .line 732
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;

    invoke-virtual {v1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;->fromInstant(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;

    move-result-object p0

    .line 737
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getYear()I

    move-result v1

    .line 739
    invoke-static {v1}, Ljava/lang/Math;->abs(I)I

    move-result v2

    const/16 v3, 0x3e8

    const/4 v4, 0x0

    const/4 v5, 0x1

    const/16 v6, 0x2710

    if-ge v2, v3, :cond_1

    .line 740
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    .line 741
    const-string v3, "deleteCharAt(...)"

    if-ltz v1, :cond_0

    add-int/2addr v1, v6

    .line 742
    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->deleteCharAt(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    goto :goto_0

    :cond_0
    sub-int/2addr v1, v6

    .line 744
    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v5}, Ljava/lang/StringBuilder;->deleteCharAt(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 746
    :goto_0
    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/CharSequence;)Ljava/lang/StringBuilder;

    goto :goto_1

    :cond_1
    if-lt v1, v6, :cond_2

    const/16 v2, 0x2b

    .line 749
    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 750
    :cond_2
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    :goto_1
    const/16 v1, 0x2d

    .line 753
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 754
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getMonth()I

    move-result v2

    invoke-static {v0, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->formatIso$lambda$0$appendTwoDigits(Ljava/lang/Appendable;Ljava/lang/StringBuilder;I)V

    .line 755
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 756
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getDay()I

    move-result v1

    invoke-static {v0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->formatIso$lambda$0$appendTwoDigits(Ljava/lang/Appendable;Ljava/lang/StringBuilder;I)V

    const/16 v1, 0x54

    .line 757
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 758
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getHour()I

    move-result v1

    invoke-static {v0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->formatIso$lambda$0$appendTwoDigits(Ljava/lang/Appendable;Ljava/lang/StringBuilder;I)V

    const/16 v1, 0x3a

    .line 759
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 760
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getMinute()I

    move-result v2

    invoke-static {v0, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->formatIso$lambda$0$appendTwoDigits(Ljava/lang/Appendable;Ljava/lang/StringBuilder;I)V

    .line 761
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 762
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getSecond()I

    move-result v1

    invoke-static {v0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->formatIso$lambda$0$appendTwoDigits(Ljava/lang/Appendable;Ljava/lang/StringBuilder;I)V

    .line 763
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getNanosecond()I

    move-result v1

    if-eqz v1, :cond_4

    const/16 v1, 0x2e

    .line 764
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 766
    :goto_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getNanosecond()I

    move-result v1

    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->POWERS_OF_TEN:[I

    add-int/lit8 v3, v4, 0x1

    aget v6, v2, v3

    rem-int/2addr v1, v6

    if-nez v1, :cond_3

    move v4, v3

    goto :goto_2

    .line 769
    :cond_3
    rem-int/lit8 v1, v4, 0x3

    sub-int/2addr v4, v1

    .line 770
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getNanosecond()I

    move-result p0

    aget v1, v2, v4

    div-int/2addr p0, v1

    rsub-int/lit8 v1, v4, 0x9

    .line 771
    aget v1, v2, v1

    add-int/2addr p0, v1

    invoke-static {p0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object p0

    const-string v1, "null cannot be cast to non-null type java.lang.String"

    invoke-static {p0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0, v5}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object p0

    const-string v1, "substring(...)"

    invoke-static {p0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_4
    const/16 p0, 0x5a

    .line 773
    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 731
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method private static final formatIso$lambda$0$appendTwoDigits(Ljava/lang/Appendable;Ljava/lang/StringBuilder;I)V
    .locals 1

    const/16 v0, 0xa

    if-ge p2, v0, :cond_0

    const/16 v0, 0x30

    .line 734
    invoke-interface {p0, v0}, Ljava/lang/Appendable;->append(C)Ljava/lang/Appendable;

    .line 735
    :cond_0
    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    return-void
.end method

.method public static final isLeapYear(I)Z
    .locals 1

    and-int/lit8 v0, p0, 0x3

    if-nez v0, :cond_1

    .line 839
    rem-int/lit8 v0, p0, 0x64

    if-nez v0, :cond_0

    rem-int/lit16 p0, p0, 0x190

    if-nez p0, :cond_1

    :cond_0
    const/4 p0, 0x1

    return p0

    :cond_1
    const/4 p0, 0x0

    return p0
.end method

.method private static final monthLength(IZ)I
    .locals 1

    .line 843
    const/4 v0, 0x2

    if-eq p0, v0, :cond_1

    const/4 p1, 0x4

    if-eq p0, p1, :cond_0

    const/4 p1, 0x6

    if-eq p0, p1, :cond_0

    const/16 p1, 0x9

    if-eq p0, p1, :cond_0

    const/16 p1, 0xb

    if-eq p0, p1, :cond_0

    const/16 p0, 0x1f

    return p0

    :cond_0
    const/16 p0, 0x1e

    return p0

    :cond_1
    if-eqz p1, :cond_2

    const/16 p0, 0x1d

    return p0

    :cond_2
    const/16 p0, 0x1c

    return p0
.end method

.method private static final parseIso(Ljava/lang/CharSequence;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;
    .locals 25

    move-object/from16 v0, p0

    .line 583
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v1

    if-nez v1, :cond_0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    const-string v2, "An empty string is not a valid Instant"

    invoke-direct {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;-><init>(Ljava/lang/String;Ljava/lang/CharSequence;)V

    return-object v1

    :cond_0
    const/4 v1, 0x0

    .line 584
    invoke-interface {v0, v1}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v2

    const/16 v3, 0x20

    const/16 v4, 0x2b

    const/16 v5, 0x2d

    const/4 v6, 0x1

    if-eq v2, v4, :cond_1

    if-eq v2, v5, :cond_1

    move v7, v1

    move v2, v3

    goto :goto_0

    :cond_1
    move v7, v6

    :goto_0
    move v9, v1

    move v8, v7

    .line 590
    :goto_1
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v10

    const/16 v11, 0x3a

    const/16 v12, 0x30

    if-ge v8, v10, :cond_2

    invoke-interface {v0, v8}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v10

    if-gt v12, v10, :cond_2

    if-ge v10, v11, :cond_2

    mul-int/lit8 v9, v9, 0xa

    .line 591
    invoke-interface {v0, v8}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v10

    sub-int/2addr v10, v12

    add-int/2addr v9, v10

    add-int/lit8 v8, v8, 0x1

    goto :goto_1

    :cond_2
    sub-int v10, v8, v7

    .line 596
    const-string v13, " digits"

    const/16 v14, 0xa

    if-le v10, v14, :cond_3

    .line 597
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected at most 10 digits for the year number, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v10}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_3
    if-ne v10, v14, :cond_4

    .line 599
    invoke-interface {v0, v7}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v7

    const/16 v15, 0x32

    invoke-static {v7, v15}, Lkotlin/jvm/internal/Intrinsics;->compare(II)I

    move-result v7

    if-ltz v7, :cond_4

    .line 600
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected at most 9 digits for the year number or year 1000000000, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v10}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_4
    const/4 v7, 0x4

    if-ge v10, v7, :cond_5

    .line 603
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "The year number must be padded to 4 digits, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v10}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_5
    if-ne v2, v4, :cond_6

    if-ne v10, v7, :cond_6

    .line 607
    const-string v1, "The \'+\' sign at the start is only valid for year numbers longer than 4 digits"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_6
    if-ne v2, v3, :cond_7

    if-eq v10, v7, :cond_7

    .line 610
    const-string v1, "A \'+\' or \'-\' sign is required for year numbers longer than 4 digits"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_7
    if-ne v2, v5, :cond_8

    neg-int v9, v9

    :cond_8
    move/from16 v16, v9

    .line 617
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v2

    add-int/lit8 v3, v8, 0x10

    if-ge v2, v3, :cond_9

    .line 618
    const-string v1, "The input string is too short"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 620
    :cond_9
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda0;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda0;-><init>()V

    const-string v9, "\'-\'"

    invoke-static {v0, v9, v8, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v2

    if-eqz v2, :cond_a

    return-object v2

    :cond_a
    add-int/lit8 v2, v8, 0x3

    .line 621
    new-instance v10, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda1;

    invoke-direct {v10}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda1;-><init>()V

    invoke-static {v0, v9, v2, v10}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v2

    if-eqz v2, :cond_b

    return-object v2

    :cond_b
    add-int/lit8 v2, v8, 0x6

    .line 622
    new-instance v9, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda2;

    invoke-direct {v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda2;-><init>()V

    const-string v10, "\'T\' or \'t\'"

    invoke-static {v0, v10, v2, v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v2

    if-eqz v2, :cond_c

    return-object v2

    :cond_c
    add-int/lit8 v2, v8, 0x9

    .line 623
    new-instance v9, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda3;

    invoke-direct {v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda3;-><init>()V

    const-string v10, "\':\'"

    invoke-static {v0, v10, v2, v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v2

    if-eqz v2, :cond_d

    return-object v2

    :cond_d
    add-int/lit8 v2, v8, 0xc

    .line 624
    new-instance v9, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda4;

    invoke-direct {v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda4;-><init>()V

    invoke-static {v0, v10, v2, v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v2

    if-eqz v2, :cond_e

    return-object v2

    .line 625
    :cond_e
    sget-object v2, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->asciiDigitPositionsInIsoStringAfterYear:[I

    array-length v9, v2

    move v10, v1

    :goto_2
    if-ge v10, v9, :cond_10

    aget v15, v2, v10

    add-int/2addr v15, v8

    .line 626
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda5;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt$$ExternalSyntheticLambda5;-><init>()V

    const-string v7, "an ASCII digit"

    invoke-static {v0, v7, v15, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v1

    if-eqz v1, :cond_f

    return-object v1

    :cond_f
    add-int/lit8 v10, v10, 0x1

    const/4 v1, 0x0

    const/4 v7, 0x4

    goto :goto_2

    :cond_10
    add-int/lit8 v1, v8, 0x1

    .line 629
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v1

    add-int/lit8 v2, v8, 0x4

    .line 630
    invoke-static {v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v2

    add-int/lit8 v7, v8, 0x7

    .line 631
    invoke-static {v0, v7}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v7

    add-int/lit8 v9, v8, 0xa

    .line 632
    invoke-static {v0, v9}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v9

    add-int/lit8 v10, v8, 0xd

    .line 633
    invoke-static {v0, v10}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v10

    add-int/lit8 v8, v8, 0xf

    .line 634
    invoke-interface {v0, v8}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v15

    const/16 v5, 0x2e

    const/16 v4, 0x9

    if-ne v15, v5, :cond_13

    move v8, v3

    const/4 v5, 0x0

    .line 638
    :goto_3
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v15

    if-ge v8, v15, :cond_11

    invoke-interface {v0, v8}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v15

    if-gt v12, v15, :cond_11

    if-ge v15, v11, :cond_11

    mul-int/lit8 v5, v5, 0xa

    .line 639
    invoke-interface {v0, v8}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v15

    sub-int/2addr v15, v12

    add-int/2addr v5, v15

    add-int/lit8 v8, v8, 0x1

    goto :goto_3

    :cond_11
    sub-int v3, v8, v3

    if-gt v6, v3, :cond_12

    if-ge v3, v14, :cond_12

    .line 644
    sget-object v13, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->POWERS_OF_TEN:[I

    rsub-int/lit8 v3, v3, 0x9

    aget v3, v13, v3

    mul-int/2addr v5, v3

    move/from16 v22, v5

    goto :goto_4

    .line 646
    :cond_12
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "1..9 digits are supported for the fraction of the second, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_13
    const/16 v22, 0x0

    .line 652
    :goto_4
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v3

    if-lt v8, v3, :cond_14

    .line 653
    const-string v1, "The UTC offset at the end of the string is missing"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 655
    :cond_14
    invoke-interface {v0, v8}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v3

    const/16 v5, 0x27

    const-string v13, ", got \'"

    move/from16 v23, v6

    const/16 v6, 0x2b

    if-eq v3, v6, :cond_17

    const/16 v6, 0x2d

    if-eq v3, v6, :cond_17

    const/16 v4, 0x5a

    if-eq v3, v4, :cond_15

    const/16 v4, 0x7a

    if-eq v3, v4, :cond_15

    .line 690
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected the UTC offset at position "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v8}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 656
    :cond_15
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v3

    add-int/lit8 v8, v8, 0x1

    if-ne v3, v8, :cond_16

    const/4 v3, 0x0

    const/4 v5, 0x3

    :goto_5
    move/from16 v4, v23

    goto/16 :goto_e

    .line 659
    :cond_16
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Extra text after the instant at position "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v8}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 662
    :cond_17
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v6

    sub-int/2addr v6, v8

    if-le v6, v4, :cond_18

    .line 664
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "The UTC offset string \""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v2

    invoke-interface {v0, v8, v2}, Ljava/lang/CharSequence;->subSequence(II)Ljava/lang/CharSequence;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    const/16 v3, 0x10

    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->truncateForErrorMessage(Ljava/lang/CharSequence;I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, "\" is too long"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 666
    :cond_18
    rem-int/lit8 v4, v6, 0x3

    if-eqz v4, :cond_19

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Invalid UTC offset string \""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v2

    invoke-interface {v0, v8, v2}, Ljava/lang/CharSequence;->subSequence(II)Ljava/lang/CharSequence;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v2, 0x22

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 667
    :cond_19
    sget-object v4, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->colonsInIsoOffsetString:[I

    array-length v14, v4

    const/4 v15, 0x0

    :goto_6
    if-ge v15, v14, :cond_1c

    aget v21, v4, v15

    add-int v12, v8, v21

    .line 668
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v5

    if-lt v12, v5, :cond_1a

    goto :goto_7

    .line 670
    :cond_1a
    invoke-interface {v0, v12}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v5

    if-eq v5, v11, :cond_1b

    .line 671
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected \':\' at index "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v12}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-interface {v0, v12}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    const/16 v2, 0x27

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_1b
    add-int/lit8 v15, v15, 0x1

    const/16 v5, 0x27

    const/16 v12, 0x30

    goto :goto_6

    .line 673
    :cond_1c
    :goto_7
    sget-object v4, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->asciiDigitsInIsoOffsetString:[I

    array-length v5, v4

    const/4 v12, 0x0

    :goto_8
    if-ge v12, v5, :cond_1f

    aget v14, v4, v12

    add-int/2addr v14, v8

    .line 674
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v15

    if-lt v14, v15, :cond_1d

    goto :goto_9

    .line 676
    :cond_1d
    invoke-interface {v0, v14}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v15

    move-object/from16 v24, v4

    const/16 v4, 0x30

    if-gt v4, v15, :cond_1e

    if-ge v15, v11, :cond_1e

    add-int/lit8 v12, v12, 0x1

    move-object/from16 v4, v24

    goto :goto_8

    .line 677
    :cond_1e
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected an ASCII digit at index "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v14}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-interface {v0, v14}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    const/16 v2, 0x27

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_1f
    :goto_9
    add-int/lit8 v4, v8, 0x1

    .line 679
    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v4

    const/4 v5, 0x3

    if-le v6, v5, :cond_20

    add-int/lit8 v11, v8, 0x4

    .line 680
    invoke-static {v0, v11}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v11

    goto :goto_a

    :cond_20
    const/4 v11, 0x0

    :goto_a
    const/4 v12, 0x6

    if-le v6, v12, :cond_21

    add-int/lit8 v6, v8, 0x7

    .line 681
    invoke-static {v0, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I

    move-result v6

    :goto_b
    const/16 v12, 0x3b

    goto :goto_c

    :cond_21
    const/4 v6, 0x0

    goto :goto_b

    :goto_c
    if-le v11, v12, :cond_22

    .line 682
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected offset-minute-of-hour in 0..59, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v11}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_22
    if-le v6, v12, :cond_23

    .line 683
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected offset-second-of-minute in 0..59, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_23
    const/16 v12, 0x11

    if-le v4, v12, :cond_25

    const/16 v12, 0x12

    if-ne v4, v12, :cond_24

    if-nez v11, :cond_24

    if-eqz v6, :cond_25

    .line 685
    :cond_24
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected an offset in -18:00..+18:00, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v2

    invoke-interface {v0, v8, v2}, Ljava/lang/CharSequence;->subSequence(II)Ljava/lang/CharSequence;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_25
    mul-int/lit16 v4, v4, 0xe10

    mul-int/lit8 v11, v11, 0x3c

    add-int/2addr v4, v11

    add-int/2addr v4, v6

    const/16 v6, 0x2d

    if-ne v3, v6, :cond_26

    const/4 v3, -0x1

    goto :goto_d

    :cond_26
    move/from16 v3, v23

    :goto_d
    mul-int/2addr v3, v4

    goto/16 :goto_5

    :goto_e
    if-gt v4, v1, :cond_2e

    const/16 v6, 0xd

    if-ge v1, v6, :cond_2e

    if-gt v4, v2, :cond_2d

    .line 694
    invoke-static/range {v16 .. v16}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->isLeapYear(I)Z

    move-result v4

    invoke-static {v1, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->monthLength(IZ)I

    move-result v4

    if-gt v2, v4, :cond_2d

    const/16 v4, 0x17

    if-le v7, v4, :cond_27

    .line 697
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected hour in 0..23, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_27
    const/16 v12, 0x3b

    if-le v9, v12, :cond_28

    .line 698
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected minute-of-hour in 0..59, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    :cond_28
    if-le v10, v12, :cond_29

    .line 699
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected second-of-minute in 0..59, got "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v10}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 700
    :cond_29
    new-instance v15, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;

    move/from16 v17, v1

    move/from16 v18, v2

    move/from16 v19, v7

    move/from16 v20, v9

    move/from16 v21, v10

    invoke-direct/range {v15 .. v22}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;-><init>(IIIIIII)V

    .line 876
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getYear()I

    move-result v0

    int-to-long v0, v0

    const/16 v2, 0x16d

    int-to-long v6, v2

    mul-long/2addr v6, v0

    const-wide/16 v8, 0x0

    cmp-long v2, v0, v8

    if-ltz v2, :cond_2a

    int-to-long v4, v5

    add-long/2addr v4, v0

    const/4 v2, 0x4

    int-to-long v8, v2

    .line 880
    div-long/2addr v4, v8

    const/16 v2, 0x63

    int-to-long v8, v2

    add-long/2addr v8, v0

    const/16 v2, 0x64

    int-to-long v10, v2

    div-long/2addr v8, v10

    sub-long/2addr v4, v8

    const/16 v2, 0x18f

    int-to-long v8, v2

    add-long/2addr v0, v8

    const/16 v2, 0x190

    int-to-long v8, v2

    div-long/2addr v0, v8

    add-long/2addr v4, v0

    add-long/2addr v6, v4

    goto :goto_f

    :cond_2a
    const/4 v2, -0x4

    int-to-long v4, v2

    .line 883
    div-long v4, v0, v4

    const/16 v2, -0x64

    int-to-long v8, v2

    div-long v8, v0, v8

    sub-long/2addr v4, v8

    const/16 v2, -0x190

    int-to-long v8, v2

    div-long/2addr v0, v8

    add-long/2addr v4, v0

    sub-long/2addr v6, v4

    .line 887
    :goto_f
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getMonth()I

    move-result v0

    mul-int/lit16 v0, v0, 0x16f

    add-int/lit16 v0, v0, -0x16a

    div-int/lit8 v0, v0, 0xc

    int-to-long v0, v0

    add-long/2addr v6, v0

    .line 888
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getDay()I

    move-result v0

    const/16 v23, 0x1

    add-int/lit8 v0, v0, -0x1

    int-to-long v0, v0

    add-long/2addr v6, v0

    .line 889
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getMonth()I

    move-result v0

    const/4 v1, 0x2

    if-le v0, v1, :cond_2c

    const-wide/16 v0, -0x1

    add-long/2addr v0, v6

    .line 891
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getYear()I

    move-result v2

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->isLeapYear(I)Z

    move-result v2

    if-nez v2, :cond_2b

    const-wide/16 v0, -0x2

    add-long/2addr v6, v0

    goto :goto_10

    :cond_2b
    move-wide v6, v0

    :cond_2c
    :goto_10
    const v0, 0xafaa8

    int-to-long v0, v0

    sub-long/2addr v6, v0

    .line 897
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getHour()I

    move-result v0

    mul-int/lit16 v0, v0, 0xe10

    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getMinute()I

    move-result v1

    mul-int/lit8 v1, v1, 0x3c

    add-int/2addr v0, v1

    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getSecond()I

    move-result v1

    add-int/2addr v0, v1

    const v1, 0x15180

    int-to-long v1, v1

    mul-long/2addr v6, v1

    int-to-long v0, v0

    add-long/2addr v6, v0

    int-to-long v0, v3

    sub-long/2addr v6, v0

    .line 900
    invoke-virtual {v15}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->getNanosecond()I

    move-result v0

    .line 700
    new-instance v1, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Success;

    invoke-direct {v1, v6, v7, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Success;-><init>(JI)V

    return-object v1

    :cond_2d
    move/from16 v9, v16

    .line 695
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Expected a valid day-of-month for month "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, " of year "

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", got "

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0

    .line 693
    :cond_2e
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Expected a month number in 1..12, got "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object v0

    return-object v0
.end method

.method private static final parseIso$expect(Ljava/lang/CharSequence;Ljava/lang/String;ILkotlin/jvm/functions/Function1;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;
    .locals 2

    .line 574
    invoke-interface {p0, p2}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v0

    .line 575
    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v1

    invoke-interface {p3, v1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Ljava/lang/Boolean;

    invoke-virtual {p3}, Ljava/lang/Boolean;->booleanValue()Z

    move-result p3

    if-eqz p3, :cond_0

    const/4 p0, 0x0

    return-object p0

    .line 578
    :cond_0
    new-instance p3, Ljava/lang/StringBuilder;

    invoke-direct {p3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Expected "

    invoke-virtual {p3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, ", but got \'"

    invoke-virtual {p3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    const-string p1, "\' at position "

    invoke-virtual {p3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    move-result-object p0

    return-object p0
.end method

.method private static final parseIso$lambda$0(C)Z
    .locals 1

    .line 620
    const/16 v0, 0x2d

    if-ne p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method private static final parseIso$lambda$10(C)Z
    .locals 2

    .line 626
    const/16 v0, 0x30

    const/4 v1, 0x0

    if-gt v0, p0, :cond_0

    const/16 v0, 0x3a

    if-ge p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    return v1
.end method

.method private static final parseIso$lambda$2(C)Z
    .locals 1

    .line 621
    const/16 v0, 0x2d

    if-ne p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method private static final parseIso$lambda$4(C)Z
    .locals 1

    .line 622
    const/16 v0, 0x54

    if-eq p0, v0, :cond_1

    const/16 v0, 0x74

    if-ne p0, v0, :cond_0

    goto :goto_0

    :cond_0
    const/4 p0, 0x0

    return p0

    :cond_1
    :goto_0
    const/4 p0, 0x1

    return p0
.end method

.method private static final parseIso$lambda$6(C)Z
    .locals 1

    .line 623
    const/16 v0, 0x3a

    if-ne p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method private static final parseIso$lambda$8(C)Z
    .locals 1

    .line 624
    const/16 v0, 0x3a

    if-ne p0, v0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method private static final parseIso$parseFailure(Ljava/lang/CharSequence;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;
    .locals 2

    .line 569
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;

    .line 570
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, " when parsing an Instant from \""

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 p1, 0x40

    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->truncateForErrorMessage(Ljava/lang/CharSequence;I)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 p1, 0x22

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    .line 569
    invoke-direct {v0, p1, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;-><init>(Ljava/lang/String;Ljava/lang/CharSequence;)V

    return-object v0
.end method

.method private static final parseIso$twoDigitNumber(Ljava/lang/CharSequence;I)I
    .locals 1

    .line 628
    invoke-interface {p0, p1}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v0

    add-int/lit8 v0, v0, -0x30

    mul-int/lit8 v0, v0, 0xa

    add-int/lit8 p1, p1, 0x1

    invoke-interface {p0, p1}, Ljava/lang/CharSequence;->charAt(I)C

    move-result p0

    add-int/lit8 p0, p0, -0x30

    add-int/2addr v0, p0

    return v0
.end method

.method private static final truncateForErrorMessage(Ljava/lang/CharSequence;I)Ljava/lang/String;
    .locals 2

    .line 867
    invoke-interface {p0}, Ljava/lang/CharSequence;->length()I

    move-result v0

    if-gt v0, p1, :cond_0

    invoke-virtual {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0

    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const/4 v1, 0x0

    invoke-interface {p0, v1, p1}, Ljava/lang/CharSequence;->subSequence(II)Ljava/lang/CharSequence;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p0, "..."

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method
