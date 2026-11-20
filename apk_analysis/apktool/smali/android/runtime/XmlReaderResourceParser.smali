.class public Landroid/runtime/XmlReaderResourceParser;
.super Landroid/runtime/XmlReaderPullParser;
.source "XmlReaderResourceParser.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/content/res/XmlResourceParser;
.implements Landroid/util/AttributeSet;
.implements Lorg/xmlpull/v1/XmlPullParser;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 15
    invoke-direct {p0}, Landroid/runtime/XmlReaderPullParser;-><init>()V

    .line 16
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Landroid/runtime/XmlReaderResourceParser;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 17
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Android.Runtime.XmlReaderResourceParser, Mono.Android"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_close()V
.end method

.method private native n_defineEntityReplacementText(Ljava/lang/String;Ljava/lang/String;)V
.end method

.method private native n_getAttributeBooleanValue(IZ)Z
.end method

.method private native n_getAttributeBooleanValue(Ljava/lang/String;Ljava/lang/String;Z)Z
.end method

.method private native n_getAttributeCount()I
.end method

.method private native n_getAttributeFloatValue(IF)F
.end method

.method private native n_getAttributeFloatValue(Ljava/lang/String;Ljava/lang/String;F)F
.end method

.method private native n_getAttributeIntValue(II)I
.end method

.method private native n_getAttributeIntValue(Ljava/lang/String;Ljava/lang/String;I)I
.end method

.method private native n_getAttributeListValue(I[Ljava/lang/String;I)I
.end method

.method private native n_getAttributeListValue(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;I)I
.end method

.method private native n_getAttributeName(I)Ljava/lang/String;
.end method

.method private native n_getAttributeNameResource(I)I
.end method

.method private native n_getAttributeNamespace(I)Ljava/lang/String;
.end method

.method private native n_getAttributePrefix(I)Ljava/lang/String;
.end method

.method private native n_getAttributeResourceValue(II)I
.end method

.method private native n_getAttributeResourceValue(Ljava/lang/String;Ljava/lang/String;I)I
.end method

.method private native n_getAttributeType(I)Ljava/lang/String;
.end method

.method private native n_getAttributeUnsignedIntValue(II)I
.end method

.method private native n_getAttributeUnsignedIntValue(Ljava/lang/String;Ljava/lang/String;I)I
.end method

.method private native n_getAttributeValue(I)Ljava/lang/String;
.end method

.method private native n_getAttributeValue(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
.end method

.method private native n_getClassAttribute()Ljava/lang/String;
.end method

.method private native n_getColumnNumber()I
.end method

.method private native n_getDepth()I
.end method

.method private native n_getEventType()I
.end method

.method private native n_getFeature(Ljava/lang/String;)Z
.end method

.method private native n_getIdAttribute()Ljava/lang/String;
.end method

.method private native n_getIdAttributeResourceValue(I)I
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

.method private native n_getStyleAttribute()I
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
.method public close()V
    .locals 0

    .line 23
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_close()V

    return-void
.end method

.method public defineEntityReplacementText(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0

    .line 268
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_defineEntityReplacementText(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public getAttributeBooleanValue(IZ)Z
    .locals 0

    .line 72
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeBooleanValue(IZ)Z

    move-result p1

    return p1
.end method

.method public getAttributeBooleanValue(Ljava/lang/String;Ljava/lang/String;Z)Z
    .locals 0

    .line 79
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeBooleanValue(Ljava/lang/String;Ljava/lang/String;Z)Z

    move-result p1

    return p1
.end method

.method public getAttributeCount()I
    .locals 1

    .line 37
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeCount()I

    move-result v0

    return v0
.end method

.method public getAttributeFloatValue(IF)F
    .locals 0

    .line 86
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeFloatValue(IF)F

    move-result p1

    return p1
.end method

.method public getAttributeFloatValue(Ljava/lang/String;Ljava/lang/String;F)F
    .locals 0

    .line 93
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeFloatValue(Ljava/lang/String;Ljava/lang/String;F)F

    move-result p1

    return p1
.end method

.method public getAttributeIntValue(II)I
    .locals 0

    .line 100
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeIntValue(II)I

    move-result p1

    return p1
.end method

.method public getAttributeIntValue(Ljava/lang/String;Ljava/lang/String;I)I
    .locals 0

    .line 107
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeIntValue(Ljava/lang/String;Ljava/lang/String;I)I

    move-result p1

    return p1
.end method

.method public getAttributeListValue(I[Ljava/lang/String;I)I
    .locals 0

    .line 114
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeListValue(I[Ljava/lang/String;I)I

    move-result p1

    return p1
.end method

.method public getAttributeListValue(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;I)I
    .locals 0

    .line 121
    invoke-direct {p0, p1, p2, p3, p4}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeListValue(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;I)I

    move-result p1

    return p1
.end method

.method public getAttributeName(I)Ljava/lang/String;
    .locals 0

    .line 128
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeNameResource(I)I
    .locals 0

    .line 135
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeNameResource(I)I

    move-result p1

    return p1
.end method

.method public getAttributeNamespace(I)Ljava/lang/String;
    .locals 0

    .line 30
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeNamespace(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributePrefix(I)Ljava/lang/String;
    .locals 0

    .line 275
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributePrefix(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeResourceValue(II)I
    .locals 0

    .line 142
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeResourceValue(II)I

    move-result p1

    return p1
.end method

.method public getAttributeResourceValue(Ljava/lang/String;Ljava/lang/String;I)I
    .locals 0

    .line 149
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeResourceValue(Ljava/lang/String;Ljava/lang/String;I)I

    move-result p1

    return p1
.end method

.method public getAttributeType(I)Ljava/lang/String;
    .locals 0

    .line 282
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeType(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeUnsignedIntValue(II)I
    .locals 0

    .line 156
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeUnsignedIntValue(II)I

    move-result p1

    return p1
.end method

.method public getAttributeUnsignedIntValue(Ljava/lang/String;Ljava/lang/String;I)I
    .locals 0

    .line 163
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeUnsignedIntValue(Ljava/lang/String;Ljava/lang/String;I)I

    move-result p1

    return p1
.end method

.method public getAttributeValue(I)Ljava/lang/String;
    .locals 0

    .line 170
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeValue(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getAttributeValue(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    .line 177
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_getAttributeValue(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getClassAttribute()Ljava/lang/String;
    .locals 1

    .line 44
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getClassAttribute()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getColumnNumber()I
    .locals 1

    .line 191
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getColumnNumber()I

    move-result v0

    return v0
.end method

.method public getDepth()I
    .locals 1

    .line 198
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getDepth()I

    move-result v0

    return v0
.end method

.method public getEventType()I
    .locals 1

    .line 205
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getEventType()I

    move-result v0

    return v0
.end method

.method public getFeature(Ljava/lang/String;)Z
    .locals 0

    .line 289
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getFeature(Ljava/lang/String;)Z

    move-result p1

    return p1
.end method

.method public getIdAttribute()Ljava/lang/String;
    .locals 1

    .line 51
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getIdAttribute()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getIdAttributeResourceValue(I)I
    .locals 0

    .line 184
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getIdAttributeResourceValue(I)I

    move-result p1

    return p1
.end method

.method public getInputEncoding()Ljava/lang/String;
    .locals 1

    .line 212
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getInputEncoding()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getLineNumber()I
    .locals 1

    .line 233
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getLineNumber()I

    move-result v0

    return v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .line 240
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getName()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getNamespace()Ljava/lang/String;
    .locals 1

    .line 247
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getNamespace()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getNamespace(Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    .line 296
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getNamespace(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getNamespaceCount(I)I
    .locals 0

    .line 303
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getNamespaceCount(I)I

    move-result p1

    return p1
.end method

.method public getNamespacePrefix(I)Ljava/lang/String;
    .locals 0

    .line 310
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getNamespacePrefix(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getNamespaceUri(I)Ljava/lang/String;
    .locals 0

    .line 317
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getNamespaceUri(I)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public getPositionDescription()Ljava/lang/String;
    .locals 1

    .line 58
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getPositionDescription()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPrefix()Ljava/lang/String;
    .locals 1

    .line 254
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getPrefix()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getProperty(Ljava/lang/String;)Ljava/lang/Object;
    .locals 0

    .line 324
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getProperty(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public getStyleAttribute()I
    .locals 1

    .line 65
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getStyleAttribute()I

    move-result v0

    return v0
.end method

.method public getText()Ljava/lang/String;
    .locals 1

    .line 261
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_getText()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getTextCharacters([I)[C
    .locals 0

    .line 331
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_getTextCharacters([I)[C

    move-result-object p1

    return-object p1
.end method

.method public isAttributeDefault(I)Z
    .locals 0

    .line 338
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_isAttributeDefault(I)Z

    move-result p1

    return p1
.end method

.method public isEmptyElementTag()Z
    .locals 1

    .line 219
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_isEmptyElementTag()Z

    move-result v0

    return v0
.end method

.method public isWhitespace()Z
    .locals 1

    .line 226
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_isWhitespace()Z

    move-result v0

    return v0
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 409
    iget-object v0, p0, Landroid/runtime/XmlReaderResourceParser;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 410
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Landroid/runtime/XmlReaderResourceParser;->refList:Ljava/util/ArrayList;

    .line 411
    :cond_0
    iget-object v0, p0, Landroid/runtime/XmlReaderResourceParser;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 416
    iget-object v0, p0, Landroid/runtime/XmlReaderResourceParser;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 417
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public next()I
    .locals 1

    .line 345
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_next()I

    move-result v0

    return v0
.end method

.method public nextTag()I
    .locals 1

    .line 352
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_nextTag()I

    move-result v0

    return v0
.end method

.method public nextText()Ljava/lang/String;
    .locals 1

    .line 359
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_nextText()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public nextToken()I
    .locals 1

    .line 366
    invoke-direct {p0}, Landroid/runtime/XmlReaderResourceParser;->n_nextToken()I

    move-result v0

    return v0
.end method

.method public require(ILjava/lang/String;Ljava/lang/String;)V
    .locals 0

    .line 373
    invoke-direct {p0, p1, p2, p3}, Landroid/runtime/XmlReaderResourceParser;->n_require(ILjava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public setFeature(Ljava/lang/String;Z)V
    .locals 0

    .line 380
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_setFeature(Ljava/lang/String;Z)V

    return-void
.end method

.method public setInput(Ljava/io/InputStream;Ljava/lang/String;)V
    .locals 0

    .line 387
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_setInput(Ljava/io/InputStream;Ljava/lang/String;)V

    return-void
.end method

.method public setInput(Ljava/io/Reader;)V
    .locals 0

    .line 394
    invoke-direct {p0, p1}, Landroid/runtime/XmlReaderResourceParser;->n_setInput(Ljava/io/Reader;)V

    return-void
.end method

.method public setProperty(Ljava/lang/String;Ljava/lang/Object;)V
    .locals 0

    .line 401
    invoke-direct {p0, p1, p2}, Landroid/runtime/XmlReaderResourceParser;->n_setProperty(Ljava/lang/String;Ljava/lang/Object;)V

    return-void
.end method
