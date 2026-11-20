.class public Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;
.super Ljava/lang/Object;
.source "FancyPrint.java"


# instance fields
.field format:Ljava/text/DecimalFormat;

.field length:I

.field significant:I


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    new-instance v0, Ljava/text/DecimalFormat;

    const-string v1, "#"

    invoke-direct {v0, v1}, Ljava/text/DecimalFormat;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->format:Ljava/text/DecimalFormat;

    const/16 v0, 0xb

    .line 32
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->length:I

    const/4 v0, 0x4

    .line 33
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->significant:I

    return-void
.end method


# virtual methods
.method public s(D)Ljava/lang/String;
    .locals 3

    .line 55
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->format:Ljava/text/DecimalFormat;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->length:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/FancyPrint;->significant:I

    invoke-static {p1, p2, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->fancyString(DLjava/text/DecimalFormat;II)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
