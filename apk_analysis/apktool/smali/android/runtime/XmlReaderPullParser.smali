.class public Landroid/runtime/XmlReaderPullParser;
.super Ljava/lang/Object;
.source "XmlReaderPullParser.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Lorg/xmlpull/v1/XmlPullParser;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Landroid/runtime/XmlReaderPullParser;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 15
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Android.Runtime.XmlReaderPullParser, Mono.Android"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_defineEntityReplacementText(Ljava/lang/String;Ljava/lang/String;)V
.end method

.method private native n_getAttributeCount()I
.end method

.method private native n_getAttributeName(I)Ljava/lang/String;
.end method

.method private native n_getAttributeNamespace(I)Ljava/lang/String;
.end method

.method private native n_getAttributePrefix(I)Ljava/lang/String;
.end method

.method private native n_getAttributeType(I)Ljava/lang/String;
.end method

.method private native n_getAttributeValue(I)Ljava/lang/String;
.end method

.method private native n_getAttributeValue(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
.end method

.method private native n_getColumnNumber()I
.end method

.method private native n_getDepth()I
.end method

.method private native n_getEventType()I
.end method

.method private native n_getFeature(Ljava/lang/String;)Z
.end method

.method private native n_getInputEncoding()Ljava/lang/String;
.end method

.method private native n_getLineNumber()I
.end method

.method private native n_getName()Ljava/lang/String;
.end method

.method private native n_getNamespace()Ljava/lang/String;
.end method

.method private native n_getNamespace(Ljava/lang/String;)Ljava/lang/String;
.end method

.method private native n_getNamespaceCount(I)I
.end method

.method private native n_getNamespacePrefix(I)Ljava/lang/String;
.end method

.method private native n_getNamespaceUri(I)Ljava/lang/String;
.end method

.method private native n_getPositionDescription()Ljava/lang/String;
.end method

.method private native n_getPrefix()Ljava/lang/String;
.end method

.method private native n_getProperty(Ljava/lang/String;)Ljava/lang/Object;
.end method

.method private native n_getText()Ljava/lang/String;
.end method

.method private native n_getTextCharacters([I)[C
.end method

.method private native n_isAttributeDefault(I)Z
.end method

.method private native n_isEmptyElementTag()Z
.end method

.method private native n_isWhitespace()Z
.end method

.method private native n_next()I
.end method

.method private native n_nextTag()I
.end method

.method private native n_nextText()Ljava/lang/String;
.end method

.method private native n_nextToken()I
.end method

.method private native n_require(ILjava/lang/String;Ljava/lang/String;)V
.end method

.method private native n_setFeature(Ljava/lang/String;Z)V
.end method

.method private native n_setInput(Ljava/io/InputStream;Ljava/lang/String;)V
.end method

.method private native n_setInput(Ljava/io/Reader;)V
.end method

.method private native n_setProperty(Ljava/lang/String;Ljava/lang/Object;)V
.end method


# virtual methods
.method public defineEntityReplacementText(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0

    .line 112
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderPullParser;->n_defineEntityReplacementText(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public getAttributeCount()I
    .locals 1

    .line 21
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getAttributeCount()I

    move-result v0

    return v0
.end method

.method public getAttributeName(I)Ljava/lang/String;
    .locals 0

    .line 119
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getAttributeName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeNamespace(I)Ljava/lang/String;
    .locals 0

    .line 126
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getAttributeNamespace(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributePrefix(I)Ljava/lang/String;
    .locals 0

    .line 133
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getAttributePrefix(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeType(I)Ljava/lang/String;
    .locals 0

    .line 140
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getAttributeType(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeValue(I)Ljava/lang/String;
    .locals 0

    .line 147
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getAttributeValue(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeValue(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    .line 154
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderPullParser;->n_getAttributeValue(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getColumnNumber()I
    .locals 1

    .line 28
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getColumnNumber()I

    move-result v0

    return v0
.end method

.method public getDepth()I
    .locals 1

    .line 35
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getDepth()I

    move-result v0

    return v0
.end method

.method public getEventType()I
    .locals 1

    .line 42
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getEventType()I

    move-result v0

    return v0
.end method

.method public getFeature(Ljava/lang/String;)Z
    .locals 0

    .line 161
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getFeature(Ljava/lang/String;)Z

    move-result p1

    return p1
.end method

.method public getInputEncoding()Ljava/lang/String;
    .locals 1

    .line 49
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getInputEncoding()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getLineNumber()I
    .locals 1

    .line 70
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getLineNumber()I

    move-result v0

    return v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .line 77
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getName()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getNamespace()Ljava/lang/String;
    .locals 1

    .line 84
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getNamespace()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getNamespace(Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    .line 168
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getNamespace(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getNamespaceCount(I)I
    .locals 0

    .line 175
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getNamespaceCount(I)I

    move-result p1

    return p1
.end method

.method public getNamespacePrefix(I)Ljava/lang/String;
    .locals 0

    .line 182
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getNamespacePrefix(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getNamespaceUri(I)Ljava/lang/String;
    .locals 0

    .line 189
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getNamespaceUri(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getPositionDescription()Ljava/lang/String;
    .locals 1

    .line 91
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getPositionDescription()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPrefix()Ljava/lang/String;
    .locals 1

    .line 98
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getPrefix()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getProperty(Ljava/lang/String;)Ljava/lang/Object;
    .locals 0

    .line 196
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getProperty(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public getText()Ljava/lang/String;
    .locals 1

    .line 105
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_getText()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getTextCharacters([I)[C
    .locals 0

    .line 203
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_getTextCharacters([I)[C

    move-result-object p1

    return-object p1
.end method

.method public isAttributeDefault(I)Z
    .locals 0

    .line 210
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_isAttributeDefault(I)Z

    move-result p1

    return p1
.end method

.method public isEmptyElementTag()Z
    .locals 1

    .line 56
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_isEmptyElementTag()Z

    move-result v0

    return v0
.end method

.method public isWhitespace()Z
    .locals 1

    .line 63
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_isWhitespace()Z

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 281
    iget-object v0, p0, Landroid/runtime/XmlReaderPullParser;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 282
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Landroid/runtime/XmlReaderPullParser;->refList:Ljava/util/ArrayList;

    .line 283
    :cond_0
    iget-object v0, p0, Landroid/runtime/XmlReaderPullParser;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 288
    iget-object v0, p0, Landroid/runtime/XmlReaderPullParser;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 289
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public next()I
    .locals 1

    .line 217
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_next()I

    move-result v0

    return v0
.end method

.method public nextTag()I
    .locals 1

    .line 224
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_nextTag()I

    move-result v0

    return v0
.end method

.method public nextText()Ljava/lang/String;
    .locals 1

    .line 231
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_nextText()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public nextToken()I
    .locals 1

    .line 238
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;->n_nextToken()I

    move-result v0

    return v0
.end method

.method public require(ILjava/lang/String;Ljava/lang/String;)V
    .locals 0

    .line 245
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderPullParser;->n_require(ILjava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public setFeature(Ljava/lang/String;Z)V
    .locals 0

    .line 252
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderPullParser;->n_setFeature(Ljava/lang/String;Z)V

    return-void
.end method

.method public setInput(Ljava/io/InputStream;Ljava/lang/String;)V
    .locals 0

    .line 259
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderPullParser;->n_setInput(Ljava/io/InputStream;Ljava/lang/String;)V

    return-void
.end method

.method public setInput(Ljava/io/Reader;)V
    .locals 0

    .line 266
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderPullParser;->n_setInput(Ljava/io/Reader;)V

    return-void
.end method

.method public setProperty(Ljava/lang/String;Ljava/lang/Object;)V
    .locals 0

    .line 273
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderPullParser;->n_setProperty(Ljava/lang/String;Ljava/lang/Object;)V

    return-void
.end method
